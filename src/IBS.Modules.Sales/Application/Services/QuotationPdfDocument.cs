using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace IBS.Modules.Sales.Application.Services;

/// <summary>
/// The client's copy of a quotation version.
/// </summary>
/// <remarks>
/// <para>
/// A flat priced list under room and category headings, which is the shape the line-item rules
/// produce: nothing nests below a line, so nothing needs to be drawn as a tree. Internal notes
/// are never rendered - they are the estimator's margin working.
/// </para>
/// <para>
/// Every figure is read off the stored row rather than recomputed. The document has to reprint
/// identically years later, whatever the rate card has done since.
/// </para>
/// </remarks>
public sealed class QuotationPdfDocument(
    Quotation quotation,
    Lead lead,
    string studioName) : IDocument
{
    private const string Rupee = "₹";

    public DocumentMetadata GetMetadata() => new()
    {
        Title = $"Quotation v{quotation.VersionNumber} - {lead.FullName}",
        Author = studioName
    };

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(28);
            page.DefaultTextStyle(t => t.FontSize(9).FontFamily(Fonts.Calibri));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    private void ComposeHeader(IContainer container)
    {
        container.PaddingBottom(12).Column(column =>
        {
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(left =>
                {
                    left.Item().Text(studioName).FontSize(16).SemiBold();
                    left.Item().Text(StageLabel()).FontSize(10).FontColor(Colors.Grey.Darken1);
                });

                row.ConstantItem(170).AlignRight().Column(right =>
                {
                    right.Item().AlignRight().Text($"Version {quotation.VersionNumber}").SemiBold();
                    right.Item().AlignRight()
                        .Text(quotation.CreatedAt.ToLocalTime().ToString("dd MMM yyyy"))
                        .FontColor(Colors.Grey.Darken1);
                });
            });

            column.Item().PaddingTop(10).Row(row =>
            {
                row.RelativeItem().Column(left =>
                {
                    left.Item().Text("Prepared for").FontSize(8).FontColor(Colors.Grey.Darken1);
                    left.Item().Text(lead.FullName).SemiBold();

                    if (!string.IsNullOrWhiteSpace(lead.Phone))
                    {
                        left.Item().Text(lead.Phone).FontColor(Colors.Grey.Darken2);
                    }
                });

                row.RelativeItem().Column(right =>
                {
                    right.Item().Text("Property").FontSize(8).FontColor(Colors.Grey.Darken1);
                    right.Item().Text(lead.PropertyName).SemiBold();

                    // The address as one line, skipping whichever parts were left blank.
                    var address = string.Join(", ", new[]
                        { lead.AddressLine1, lead.AddressLine2, lead.City, lead.State, lead.PinCode }
                        .Where(part => !string.IsNullOrWhiteSpace(part)));

                    if (!string.IsNullOrWhiteSpace(address))
                    {
                        right.Item().Text(address).FontColor(Colors.Grey.Darken2);
                    }
                });
            });

            column.Item().PaddingTop(10).LineHorizontal(1).LineColor(Colors.Grey.Medium);
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(14);

            foreach (var room in quotation.Rooms.OrderBy(r => r.SortOrder))
            {
                if (room.LineItems.Count == 0) continue;

                column.Item().Element(c => ComposeRoom(c, room));
            }

            column.Item().PaddingTop(6).Element(ComposeTotals);
        });
    }

    private void ComposeRoom(IContainer container, QuotationRoom room)
    {
        container.Column(column =>
        {
            column.Item().Background(Colors.Grey.Lighten3).Padding(6).Row(row =>
            {
                row.RelativeItem().Text(room.RoomName).SemiBold().FontSize(11);
                row.ConstantItem(110).AlignRight().Text(Money(room.RoomTotal)).SemiBold().FontSize(11);
            });

            // Grouped by category, in the order the lines were laid out, so the printed document
            // reads in the same order as the tab it was built in.
            var categories = room.LineItems
                .OrderBy(i => i.SortOrder)
                .GroupBy(i => i.CategoryKey, StringComparer.Ordinal);

            foreach (var category in categories)
            {
                column.Item().PaddingTop(6).Text(category.First().CategoryName)
                    .FontSize(8).SemiBold().FontColor(Colors.Grey.Darken2);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3.2f);   // particulars
                        columns.RelativeColumn(1.6f);   // specification
                        columns.RelativeColumn(1.1f);   // size
                        columns.RelativeColumn(0.9f);   // quantity
                        columns.RelativeColumn(1.0f);   // rate
                        columns.RelativeColumn(1.3f);   // amount
                    });

                    table.Header(header =>
                    {
                        HeaderCell(header, "Particulars");
                        HeaderCell(header, "Specification");
                        HeaderCell(header, "Size (ft)");
                        HeaderCell(header, "Qty", alignRight: true);
                        HeaderCell(header, "Rate", alignRight: true);
                        HeaderCell(header, "Amount", alignRight: true);
                    });

                    foreach (var line in category)
                    {
                        BodyCell(table).Column(c =>
                        {
                            c.Item().Text(line.ItemName);

                            if (!string.IsNullOrWhiteSpace(line.Notes))
                            {
                                c.Item().Text(line.Notes!).FontSize(7.5f).FontColor(Colors.Grey.Darken1);
                            }
                        });

                        BodyCell(table).Text(Specification(line)).FontColor(Colors.Grey.Darken2);
                        BodyCell(table).Text(Size(line)).FontColor(Colors.Grey.Darken2);
                        BodyCell(table).AlignRight().Text(QuantityLabel(line));
                        BodyCell(table).AlignRight().Text(line.Rate == 0 ? "-" : Money(line.Rate));
                        BodyCell(table).AlignRight().Text(Money(line.Amount));
                    }
                });
            }
        });
    }

    private void ComposeTotals(IContainer container)
    {
        container.AlignRight().Width(260).Column(column =>
        {
            column.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);

            TotalRow(column, "Subtotal", quotation.Subtotal);

            if (quotation.DiscountAmount > 0)
            {
                var label = quotation.DiscountPercent is { } percent
                    ? $"Discount ({Trim(percent)}%)"
                    : "Discount";

                TotalRow(column, label, -quotation.DiscountAmount);
                TotalRow(column, "Taxable value", quotation.TaxableValue);
            }

            TotalRow(column, $"GST ({Trim(quotation.GstRatePercent)}%)", quotation.GstAmount);

            if (quotation.TransportCharges > 0)
            {
                TotalRow(column, "Transportation", quotation.TransportCharges);
            }

            if (quotation.InstallationCharges > 0)
            {
                TotalRow(column, "Installation", quotation.InstallationCharges);
            }

            column.Item().PaddingTop(4).LineHorizontal(1).LineColor(Colors.Grey.Darken1);

            column.Item().PaddingTop(4).Row(row =>
            {
                row.RelativeItem().Text("Grand total").SemiBold().FontSize(11);
                row.ConstantItem(120).AlignRight().Text(Money(quotation.GrandTotal)).SemiBold().FontSize(11);
            });
        });
    }

    private void ComposeFooter(IContainer container)
    {
        container.PaddingTop(10).Column(column =>
        {
            column.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

            column.Item().PaddingTop(4).Row(row =>
            {
                row.RelativeItem().Text(
                        $"{studioName} - quotation v{quotation.VersionNumber}. All figures in INR.")
                    .FontSize(7.5f).FontColor(Colors.Grey.Darken1);

                row.ConstantItem(70).AlignRight().Text(text =>
                {
                    text.DefaultTextStyle(t => t.FontSize(7.5f).FontColor(Colors.Grey.Darken1));
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        });
    }

    // --- Cells and formatting ----------------------------------------------------

    private static void HeaderCell(TableCellDescriptor header, string text, bool alignRight = false)
    {
        var cell = header.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Medium).PaddingVertical(3);

        (alignRight ? cell.AlignRight() : cell)
            .Text(text).FontSize(7.5f).SemiBold().FontColor(Colors.Grey.Darken2);
    }

    private static IContainer BodyCell(TableDescriptor table) =>
        table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).PaddingVertical(3).PaddingRight(4);

    private static void TotalRow(ColumnDescriptor column, string label, decimal value)
    {
        column.Item().PaddingTop(3).Row(row =>
        {
            row.RelativeItem().Text(label).FontColor(Colors.Grey.Darken2);
            row.ConstantItem(120).AlignRight().Text(Money(value));
        });
    }

    private string StageLabel() =>
        quotation.Stage == QuotationStage.Initial ? "Initial quotation" : "Final quotation";

    private static string Specification(QuotationLineItem line)
    {
        var parts = new[] { line.CarcassMaterial, line.ShutterMaterial, line.Finish }
            .Where(p => !string.IsNullOrWhiteSpace(p));

        var text = string.Join(" / ", parts);

        return text.Length == 0 ? "-" : text;
    }

    private static string Size(QuotationLineItem line) => line.UnitOfMeasure switch
    {
        QuotationUnitOfMeasure.SquareFeet when line.WidthFeet is not null && line.HeightFeet is not null =>
            $"{Trim(line.WidthFeet.Value)} x {Trim(line.HeightFeet.Value)}",
        QuotationUnitOfMeasure.RunningFeet when line.WidthFeet is not null =>
            $"{Trim(line.WidthFeet.Value)} rft",
        QuotationUnitOfMeasure.CubicFeet when line.WidthFeet is not null && line.HeightFeet is not null =>
            $"{Trim(line.WidthFeet.Value)} x {Trim(line.HeightFeet.Value)} x {Trim(line.DepthFeet ?? 0m)}",
        _ => "-"
    };

    /// <summary>
    /// What the rate is actually multiplied by, which is the billable quantity rather than the
    /// count - showing "1" against a 47.6 sq.ft line would make the arithmetic on the page look
    /// wrong to the person checking it.
    /// </summary>
    private static string QuantityLabel(QuotationLineItem line)
    {
        var unit = line.UnitOfMeasure switch
        {
            QuotationUnitOfMeasure.SquareFeet => " sft",
            QuotationUnitOfMeasure.RunningFeet => " rft",
            QuotationUnitOfMeasure.CubicFeet => " cft",
            _ => ""
        };

        var quantity = line.UnitOfMeasure == QuotationUnitOfMeasure.Number
            ? line.Quantity.ToString()
            : Trim(line.BillableQuantity) + unit;

        return line.Quantity > 1 && line.UnitOfMeasure != QuotationUnitOfMeasure.Number
            ? $"{quantity} x {line.Quantity}"
            : quantity;
    }

    private static string Money(decimal value) => $"{Rupee}{value:N2}";

    /// <summary>Drops trailing zeros so 2.80 prints as 2.8 and 17.00 as 17.</summary>
    private static string Trim(decimal value) => value.ToString("0.###");
}
