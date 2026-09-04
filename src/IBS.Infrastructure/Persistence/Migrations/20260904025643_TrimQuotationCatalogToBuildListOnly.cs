using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IBS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TrimQuotationCatalogToBuildListOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("016423b5-c35f-e21b-7e20-e812da7325bc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("02f9a7b1-e4a1-8608-f313-1b207e76ace8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("091f22b0-0eee-e0e9-f917-fe04bd025644"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0953a34b-dc99-041d-e996-c5a2ced7da0c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0ca90629-5d85-3933-6bfc-1b6601e65e84"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0f3c6702-2d92-f9ef-b3c7-d210e291d830"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1291e7ad-d1ba-2ace-3786-8917e9275dc6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("15d9a239-d43c-98b1-fa1f-1bfca0ee1c42"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("17347ad8-5fa8-9f04-2beb-cf2a52fb9999"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("17452e4a-7a23-d622-14e1-e5a5010ac2bd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1855560f-2d0d-6e9d-108a-8ae6977f9d46"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("19a2638d-e298-19bd-abce-0eb2a56f0b46"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1aef18cc-f26e-83fe-9915-8971a1c6c2b4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1bffd968-e2a8-1c80-490f-78b2a1c0aabc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1c9b3e4d-3b9a-0ec4-b172-7fa545748b99"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1cda3973-15fb-46ca-86d9-29f0e279fef2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1ce6193a-a9fd-19ff-7057-a9169cf66160"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1eeb8297-0939-ee4d-2be8-89b6f3ddc3d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1f97773b-fcbe-3926-095a-22ee342bd62d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1fe4f814-271c-70fa-23f1-e7707ee193df"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("223779c5-73c7-361f-d324-d66bd0e20014"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("22951f32-f082-b8e8-a4ed-d3ea4979a74f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("22c76a62-b35c-02fc-0e07-359582a6171e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("240cbf98-39c9-fbd3-4c40-1eed428c5c1f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("24717e96-f282-0d36-7cd2-f0a3b9a3d5a5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("25e1317b-1c2a-570c-c8e3-34f94abb3e03"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2836ef4d-ecd9-b771-5061-8672ea3e8287"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("286d4e16-cf3e-c089-e342-61e75382429b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2b53036f-c0b1-4a71-d123-09e8f5695148"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2ce11485-fdaf-9dc1-91ee-0ea19165aa9f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2ff3f8ce-627b-2337-6792-8c8a64ac9044"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("303cd321-4595-46f5-0236-1bbb7dfeb879"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("32857d4e-2041-198d-bb44-355a1f80ea94"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("351a6ffc-2c38-8592-5405-9d2a79c5fe38"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("37fd4d57-1904-7218-5390-7e318efdbb99"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("39fb1839-45ff-abd7-d967-7845f7a06788"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3f648144-247f-d771-fb18-687228688a4a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3f704865-0dc4-225c-5ddf-7043c990cc05"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("452abcad-7508-04ad-a2bb-72ea868e2d1a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("46a9918f-5e5c-a1be-a3fe-16e57e20002b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("480c3993-eb4a-2f69-cdf3-35024c734d15"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("486890cb-0291-5c20-4bd4-0b0debc2859f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4a48413f-e62f-fa9c-2bdc-92461169ffd8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4ab483d7-1b47-0059-9638-ca42b00ba91a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4c7481c0-4dbe-1e7b-323d-615e27c0679e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4e1c667d-5fd0-b57c-6dd7-8b65890d2b86"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4e671144-e82e-5c3a-a732-250121616d20"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("54552d0a-f321-f6d2-4a2a-6c4cf64c8c5e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("54a33f97-e744-65f6-9f16-9d83900b66b3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5538bf6b-afc0-afab-5159-c7aac6e76d26"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5576888d-a8a0-fcba-dc2c-d273aa73c9f3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("55ef0364-6f94-613f-277c-2e1795963a50"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("561a8fa6-6a2b-b3b6-85c5-310380c67f6d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("56241518-5690-f55e-eede-d4298bdada13"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5725bcff-8ca4-80b5-0b61-c36373ed57df"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5bbeb36d-f8a8-ee18-4187-3dc617f8ce25"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5bebe991-bb98-0bd6-d6fa-0a5f82e2e8c2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5cf5c534-1f07-18c3-c03a-f0df0944317e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5d281df7-bebf-99f2-c42c-f2d822f3f0e3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5d85aa51-829b-6a0c-5a56-ced0f93d4e2e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5e23fe87-ca6d-56f2-5f97-f65552f690d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5eb679f7-04fd-f0e9-c627-852f3d4d549c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5ed00924-d3f8-1ddf-e27f-13009532f681"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5f663cb3-ee93-2538-7666-1de74b24e339"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5ffa552d-2da7-5c8e-6e2b-5d7c9b7d52de"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6069a039-958a-c47a-db27-d33a214fc65f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("60e3c213-a7c1-660c-b4dd-9e2b16e14616"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("60ed067c-b4c1-ae35-f7e4-02d76fc80ed3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("613ada14-2a82-3c4f-e507-c04931f782cc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("61e6bba7-2a87-10e4-18ac-04eb694c3f34"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("63f0e8cb-7119-1a2f-fd52-4b9f2576dd59"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("64d317a0-a4d0-81f1-3025-9bb1db45a6e7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("66be3a86-7410-cf9f-1fd0-3a52ad895543"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("67646666-bf67-3eb3-5876-e9a9655c0d11"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("681b0348-772d-2600-1435-a04f3673999a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6cb7f51d-625e-2229-c95b-e6585577c361"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6d0c4cba-71d3-c825-0872-0bfdb0f802ee"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6e43f452-d004-55c5-b117-e739f182b960"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7013e9bc-743f-4fae-1de1-125875eab95f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7177cfc8-c077-947d-d38d-db429090d0ca"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7256070b-395b-d260-b424-38c557ba0565"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("740b22e7-37fe-1934-4ed1-88cf46c09cba"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7551f391-d866-923c-8d7f-01f85c42c1c6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("76c70884-adab-a3c4-dbb9-8cb5229a6556"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7afc6fc9-132c-ac4b-9b2c-aab07ea5addc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7b0ef488-6b0e-3c25-9fd8-45a4df9f2894"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7d911351-f769-f2a3-b4d5-70fcfe3734aa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7e7f8c75-ff94-c870-d88b-264bdbefb931"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7ff96626-cb6c-d2b9-59b2-2e1a78dedc0b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("80e54c61-f0a2-e6a0-05d8-14dfcf525829"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("81dfbaea-489b-9cda-39aa-491c08f69698"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8317d36b-d047-58c9-9c8d-c50be956f411"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("842455d4-edc6-642e-d6b8-ee8448aa78b3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("84a70b46-1b55-c275-4a2a-c325c5590df2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("84d6272a-3092-5b74-93b1-316b64086f59"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8622bcbe-b62b-9825-cdb6-ab4dadf8330d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89a0aa9d-9566-86bc-7f0e-820df1ceffd1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89b1e1d6-01b6-597a-4711-0786e5655be5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89b2e6a3-7c33-4863-42c8-211b49d51d67"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("89e1d789-38d2-4861-a567-b9661efaa685"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8bf70c75-0c40-1431-b3a8-5f7aa85c8e1c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8c5a90af-8328-4767-2a7c-90ab98bc4339"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8cde98a8-5bf6-1e2d-afe3-56f69d20cac4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8d68451a-399d-a33b-1e6e-91fcead2831e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8d6acfb7-c5ad-568a-b454-cadf10622659"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8db2cdd0-6a45-3cc2-f6f4-d7fc2fcf7417"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8e912744-2d39-4669-5128-4cc4d6ab4725"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8ef4477b-108c-93c9-bed3-d6b95ea8013f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8f0683b9-fe47-7bce-fe90-a86003c0f97b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8fe0e6e4-cd54-b34e-8496-8fd61ab11a71"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("92f928e6-df2e-fad9-09cd-dd1713cc12d5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("93a69f8e-57cf-2716-8e58-83d5ad72549c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("948e93ce-b1fa-a11d-65c6-2ff94e5e812d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9606c256-8e0c-4769-9e02-42f11613ead5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("963018bc-8482-4b9b-1c71-d3f045ff1455"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("96f084c0-009e-394e-7ff8-92565dd2028e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("973674ad-8917-307b-d7eb-de68b1c3b1c9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("976d1a44-2eb4-4a3c-4223-e10653e0d497"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("99efcb62-3315-a9f3-3991-9375d7af31a3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9ce9fdeb-6b1f-1095-cefd-a92a95153619"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9ea52c02-629b-5201-9e44-c89728c68f9b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a183877e-716f-b946-c20d-37a0bf2b4f4a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a2a45073-82b7-e36a-bbd9-8f98624e5559"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a40dfb14-f3fa-98b5-65e7-8ad4f48a7ec9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a59c6394-5def-733e-733e-3667e6f17abe"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a669cd65-975e-4904-900d-02214ed2e2c5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a6fb7bf3-e3a1-88a5-30d8-45b3122cd583"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a7fc34ed-0d31-7f6b-3c0f-d78b91f6035e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a8e5c3da-98a0-b5d0-d505-62d8bab6a3b3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("aa8eb7ab-4b7e-763e-bae8-127881791021"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ac2fb669-4922-bbdd-885b-919a8c62cd9e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ac40642d-9d0e-76a8-324a-8593f6b640ed"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("acf4aef2-e551-2159-ad45-4c053b87c1a6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b3cd1a04-464c-a484-7ee2-7e3332be6e7d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b5a8a7f2-b04b-ea3e-18af-80bd16dfbccd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b88f599c-9b90-4bd5-56bd-87285f94d215"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b9af130b-b9e3-a6f5-20c6-09e4dfa8ba43"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ba2f2c50-4316-dc18-87e7-ae0ae6d11c3b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("baf3c598-4a02-658c-92dc-214500406d07"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bb19e104-876d-f532-af36-95fb7bcf7459"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bbe388be-2ad9-5316-0b0c-8c32b0392274"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bd2306ad-b7dc-2719-af2a-49fc171cb0da"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bd42864a-f117-9b92-3f60-fd399cf66a34"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bf8275cd-e391-a72f-8d59-1670386e47af"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bff0369c-3962-ba78-394f-a8bbcda00fd2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c08db93d-2cf3-8d3b-2ac7-1304d8fddd52"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c14f66cb-c3d6-8027-948e-28f66a1e6a52"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c21acf4c-f03d-69d5-bf57-d1c4fd8126ae"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c292e758-2267-c963-8cb6-7917152bac09"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c2ecb214-8196-97a6-beb5-607725cdadf9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5e01000-9a70-4044-05b2-bef0b439da18"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5fc00ce-ece2-c8f6-4747-8f78c0b88d92"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c76a0438-4600-5237-f1e2-c66b141df12e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c7b0e1f3-5e7c-7bed-4fa3-9e8a4fbe4744"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c8543641-52ea-2bd3-96b4-c697d6a338c4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c93df9f8-8f78-94f6-5792-eec485b76bc7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c94ce885-b734-8fa2-9302-b47bd711cdd8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c9d6c282-34b2-f86b-16dd-bdb4524de2bc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c9eede4e-a70e-a372-e59f-00ed5e52823a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ca174937-dffd-a8d0-4d80-79e4620ddbad"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cf283c9f-2850-a1d1-5993-c6e6afada52e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d184f702-0d39-c3e8-6ecc-c2b4137acfd7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d344efbc-75ae-e70b-085f-4ba8c11d1e10"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d3e3720f-4677-0a27-bf7e-fcb64448cdc0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d552ec0b-c683-f55e-3bb5-d8c2b158b8e9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d5ffea32-e0e6-c37a-e7b2-adabdc10499a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d749db7d-091d-86d8-a9d9-5dda78954b17"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("da9c4317-ec72-2819-5f4b-af3b65caa955"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("db38bbf2-8195-7b0f-fc80-db4c86702a08"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("db8973a2-3bd0-eaba-c464-23f693611bb7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dc07aec4-0bda-87a6-ba92-261180e2181c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dc2627b4-f9af-4589-1eb8-fa6207dd0275"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dcdc6444-c6a1-b849-22c6-28126387e1c3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ddc11574-d840-64de-6023-c7d47c6b4daa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e01f66c9-8251-9920-0e73-5b550bc8f957"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e041ba71-583b-abfb-09ee-db7e1163a98f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e0732ae9-2ac7-731c-201a-af8634c66c6c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e07ea364-9cba-2ac2-f621-9780bed6d020"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e0a73010-0ed5-3374-ede3-445731fce633"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e32482e9-2ebd-889a-0dc9-67611b515cd1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3ebb2be-9e35-5cef-9b07-e86c022a0966"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4bf6dfd-3a25-8ea7-8f59-f67e83d4e587"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ea1484fa-dd7b-8200-0386-7c1557d7b585"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ea22d1d4-99b3-cd60-5ede-95ee312a9cbb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec0959a6-3f22-974f-c725-45ee6340333e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec4f75b5-a3b7-216a-03dd-169088351ecb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec96e3e8-f7c4-138b-8cc3-39ddf800c9e0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed117801-ad5f-c3fd-4252-f7d9700f05fc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed18318d-2dde-a226-a70d-1e95083c452b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed72e572-8454-6471-f082-9ea35c18e444"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ee874ffa-921d-7c06-4d9b-00c0feaa7284"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("eef1154b-e8d3-edab-f3b3-717a56b5842d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f0325c02-e099-589b-a748-601aaf1de3f1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f1a36782-3538-4b3e-5305-8e1aa541cfff"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f394106a-4e4e-74d5-dc92-4e4a0707a05d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f3a6c3a1-6af2-cb34-791f-92d27da0bf56"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f3e07188-8fda-dabe-7b8b-a58ec2c1eb3b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f5e8b08b-2461-b66b-2dd6-63e5e7645bd3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f795d839-d606-9471-f535-81bc48b34fcb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f9ed2173-97ac-63d7-f8c0-9fc909a4992f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fbfa8ca2-b208-7da7-c830-017be1ad0c69"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fc451b46-1cce-836b-5fcd-34609e4a05c0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fc5e7e57-abb3-bd3f-9d18-91a00f00b1eb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fd3e7023-600a-279a-24c4-22d586b6de6b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fd9c9c00-5407-459b-eda9-a83f237019e8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fe364e61-11ff-5b5c-e050-af1dc79932ca"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("039c6aa9-80c5-6841-3cfc-277813a9e27c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("0c9297fe-a7f4-8185-66de-810a0887ae88"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("12e62c24-fbfb-dbbc-8813-884661757690"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("153d6b68-950c-8450-c56a-30674dc7e687"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("1a77a17f-d906-5578-f11c-730230c4db27"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("1b5186b2-9740-ab06-cef6-0e297ada3683"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("2069b4dc-8e26-d3e5-b145-7d81b717a9e6"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("28a05ef8-da4e-2821-e42f-c0911c5af2e7"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("2cb4e615-90cd-e74d-7691-f83918fbb31a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("30b421a4-9c7c-64af-70f7-bbb7d4901c42"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3bf281c2-fda8-3d00-9357-6160301c1d42"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3d1d1bf5-cc48-0c66-457f-3cfe7ba517b9"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3df61d4e-92d0-2908-1f04-4f2ab63f9b22"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("477d2462-f597-33f6-54c0-d0e64cc00f14"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4af4b50c-53f9-0d32-2e89-66e53defeb02"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4c560537-8cf3-b173-a8ec-586095507fda"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4f7a88bc-23ff-bc2b-a0a0-14fc058422ec"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("50cbfd48-70e4-c297-e525-af90929e2865"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("57410f5e-1461-d13e-e003-46b62352da78"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("57a75156-a75e-bd88-d33d-024027456c7e"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6057afbf-feb6-8ab8-a818-1ec7e95caf77"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("63858fb0-ae6b-4fbb-16d8-05c54da5a105"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("63aee5bb-3d60-6aa5-9a15-326fcb19f6b5"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("63e8ca8d-4725-1f5a-d280-6e788de7a9ca"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("68551bfa-72fb-1fc0-6c35-808a482a4d9b"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6a4281e2-73c0-6799-9d4c-98f276394c32"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6c8e4e17-aba0-98c9-a548-bb2c5848abbf"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6e86fff1-efa9-b455-0de6-974491be5ef7"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6f9ad67f-03de-62a2-a6be-006fe4d0edb6"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("74031370-9dcf-3a1a-e7f8-b299005e2d1a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("766c30b8-be5c-596c-10db-94a0f318ffc7"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("7f583bea-6d0a-06e9-dc07-18746126a4e3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("8a4f5987-ebd3-26f2-fe44-0b787a908443"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("8d378ed8-d938-cdbb-f743-2deab5d25104"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9045633f-c77d-706e-c49e-0dc241d66c82"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("92a5cdc8-65cb-de09-4d07-a0c62b8793ca"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("972b45d9-9bc8-851a-0a31-7d288d70aa64"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9739a6d2-f17d-02d1-2f96-2bab5e28d2cb"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("98f973c8-e209-70c0-46e1-605d98593fff"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9a8d0ec8-2657-f122-2401-b09d881b8b3e"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9df2fd07-424d-25b4-e7d1-93cdcd74e0c9"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9e830e1e-e44c-6094-8dcd-7e33e1c27bfc"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a1ee74b0-7711-b449-aa7f-768cea50e2c8"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a20ffbd1-c32f-3f10-a34f-63cd706b650c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a96f91e9-a77f-2392-3fb3-0e7e20dd99cb"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("af285b6a-9530-ace2-1bcf-45281a02ecdf"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b684da8b-af3f-0930-d65a-b86e97343af8"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("c4352f6c-3521-5c03-2e24-371181339e3d"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("c4fc4430-cf12-c71e-b43c-badd25d83a26"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d10c259b-2160-bdd2-de99-a97174ea3ac6"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d966e803-e6b3-6283-db9a-e799ff609e79"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("da00908b-0152-62a9-cab5-19686f1d7762"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("dd98ac50-3071-a054-8878-60a8822decae"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("e15bc135-8a46-5355-a790-1b6db34b36d3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("e4e8451b-b1d7-9c37-0c8f-48a799164eb0"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("e7f7fd7c-68cb-1bb8-2540-cfd73ad6edb1"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("ecc8d789-593b-3716-707e-f583b1796a76"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("ee596b21-b4e8-bafc-3292-23ea68380cbc"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("fabaa00d-555e-d02c-09c5-05f49a21338c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("fca76c78-a5ac-2612-8350-9b06230f3314"));

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("02fffa74-1d59-4a05-00ac-949494c07c15"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "dining-room", 6, 2, null, null, "", "" },
                    { new Guid("04a9b948-028e-ab01-db09-9fb7f6fe3b53"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "master-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("05394ad6-9744-88b4-943c-87cd2a103943"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "living-room", 7, 1, null, null, "", "" },
                    { new Guid("05668faa-83ad-ddd8-3e52-b27a2c3c3b02"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "drawing-room", 3, 1, null, null, "", "" },
                    { new Guid("060a4f02-7324-1663-eea6-8ac6012f66df"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "janitor-unit", "Janitor Unit", 1, "utility", 5, 1, null, null, "", "" },
                    { new Guid("065e91ef-d7ee-24da-609d-f34dbb6f2cc5"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bar-unit", "Bar Unit", 1, "drawing-room", 1, 1, null, null, "", "" },
                    { new Guid("08166876-f97b-2de3-263b-7c1060c3731b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "used-clothes-wardrobe", "Used Clothes Wardrobe", 1, "guest-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("08944344-7be1-6505-74ab-936681def752"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "dining-room", 3, 4, null, null, "", "" },
                    { new Guid("097375b5-4414-1cd4-789a-298b3c3f6599"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "drawing-room", 6, 4, null, null, "", "" },
                    { new Guid("0a0b3520-291f-45a8-3882-21e51cccc38b"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "fluted-panel", "Fluted Panel", 1, "kitchen", 1, 1, null, null, "", "" },
                    { new Guid("0b2c1fb9-6b8c-c88a-0171-b56ec7b6d608"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "drawing-room", 2, 2, null, null, "", "" },
                    { new Guid("0be8f9e8-a419-dc7f-ae2c-fa258c97a405"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("0dfa32cb-18d6-323a-346e-c1ec0d4c31c3"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "master-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("131f0c03-07c7-8a3c-3f17-12096c4502f1"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "dining-room", 2, 4, null, null, "", "" },
                    { new Guid("1346bb22-4ae6-0542-2458-8a79498a2865"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "dining-room", 5, 2, null, null, "", "" },
                    { new Guid("166654ee-5c10-2652-8445-0f8370e8b15a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "master-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("18f6a19e-f937-2e0b-19c1-1e53d49d9356"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "living-room", 4, 2, null, null, "", "" },
                    { new Guid("1993cf73-f1c9-cced-0407-2be02cfda20a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "kitchen", 6, 2, null, null, "", "" },
                    { new Guid("19eb86f4-3aed-e77f-6424-943c1d4e0ca9"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "dining-room", 1, 4, null, null, "", "" },
                    { new Guid("1a1143a9-2c71-5e68-79f6-630d0b9adfd0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "dining-room", 2, 2, null, null, "", "" },
                    { new Guid("1b662243-588c-8afd-1a80-c00a89695702"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "bedroom", 7, 2, null, null, "", "" },
                    { new Guid("1bce4df8-f075-6edb-ea0e-c863b6383a6f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "dining-room", 7, 1, null, null, "", "" },
                    { new Guid("1d2b4836-8ce7-66a7-3ca1-fd3c5801c40a"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "bedroom", 5, 2, null, null, "", "" },
                    { new Guid("1d9b86f5-bd70-7f91-8198-c09cb60d4683"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "bedroom", 2, 1, null, null, "", "" },
                    { new Guid("1e2cb815-e2d0-9a73-8d7a-264ba795e822"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "kids-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("20c27454-8fa5-e2fb-847f-652bb8d2527c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "kids-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("21d67a95-c5db-42b4-ffba-c7135b2a4dff"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("24b2577b-01d9-a738-f1bb-d5a312bf8894"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "master-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("24d26859-44c4-8bae-759b-8344704aad29"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "living-room", 2, 1, null, null, "", "" },
                    { new Guid("28631194-80bf-904b-4d0b-fe6f900523a9"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "main-door-paneling", "Main Door Paneling", 1, "main-door", 1, 1, null, null, "", "" },
                    { new Guid("2930f2c1-63a3-40a5-42b4-6ddb9f8ad2a6"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "living-room", 2, 4, null, null, "", "" },
                    { new Guid("2b1ec648-2c59-8c6c-d9c4-c477bd90cfeb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bar-unit", "Bar Unit", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("2d8905f6-239e-4c1c-7990-5ccac4652f85"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-full-height", "Sliding Wardrobe - Full Height", 1, "kids-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("2f011022-a52f-159f-2953-60f0b4ef1c50"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-7", "Sliding Wardrobe - 7'", 1, "bedroom", 2, 1, null, null, "", "" },
                    { new Guid("2f97731e-48c9-b112-de29-3529a5551329"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "arch", "Arch", 1, "kitchen", 0, 2, null, null, "", "" },
                    { new Guid("34e549e9-242a-609c-734d-2e2d196e51d0"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains-blind", "Curtains / Blind", 1, "drawing-room", 3, 1, null, null, "", "" },
                    { new Guid("37ae8eb8-3f23-84c0-8de6-7163f93c7438"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-7", "Sliding Wardrobe - 7'", 1, "guest-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("38a8aed6-3726-9e07-a6f5-2f16b048a5f5"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "used-clothes-wardrobe", "Used Clothes Wardrobe", 1, "bedroom", 6, 1, null, null, "", "" },
                    { new Guid("38ce5749-64a9-91c7-d4d4-bbd9a34f3217"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "guest-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("3974fdaa-350f-7af0-feb4-eea95ca04525"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "drawing-room", 1, 4, null, null, "", "" },
                    { new Guid("3ad3aa4b-5b87-d5b4-a593-3f5957ba578c"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling-paint", "False Ceiling + Paint", 1, "living-room", 0, 1, null, null, "", "" },
                    { new Guid("3b74d71f-4f35-b548-6e00-1b4551d015ba"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-full-length", "Hinged Wardrobe - Full Length", 1, "bedroom", 1, 1, null, null, "", "" },
                    { new Guid("3befd059-4953-b414-39f7-bfbec0e44327"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("3c802de9-3573-057e-0cbc-f79a51d36bfd"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("3e90cda2-8f2c-6c07-7f59-8d98dd9689fb"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "living-room", 7, 2, null, null, "", "" },
                    { new Guid("41183445-01de-1054-2916-412e92884c15"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("446b5b81-f658-b07c-dffc-70fa118422dd"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "dining-room", 9, 1, null, null, "", "" },
                    { new Guid("4540cb65-aca0-7e9d-7888-883fdfa2d7c1"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pantry-unit", "Pantry Unit", 1, "kitchen", 4, 1, null, null, "", "" },
                    { new Guid("456eaeac-73e7-0d1c-4afe-ebcc2476962c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "guest-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("47ca1e7a-4fc6-c4d9-74ed-efa9f1ac0edb"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "kitchen", 7, 2, null, null, "", "" },
                    { new Guid("489198b5-c376-8b27-fc5b-5a6c312bd567"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "dining-room", 5, 2, null, null, "", "" },
                    { new Guid("4c6cfc0e-2066-50c1-e695-8dc98438dd93"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-7", "Hinged Wardrobe - 7'", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("5135daba-b0aa-982b-7057-e539d89a2d02"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains-blind", "Curtains / Blind", 1, "dining-room", 4, 1, null, null, "", "" },
                    { new Guid("5563f0c3-4762-6576-f908-e9828bdb1f73"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "guest-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("585c5a6f-cf25-c39f-a844-4144f97f551a"), 8500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sink", "Sink", 2, "kitchen", 8, 4, null, null, "", "" },
                    { new Guid("58c91a09-c2e1-928b-2bcb-138f57b924f9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "book-shelf-unit", "Book Shelf Unit", 1, "guest-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("58d22483-3a6c-30b0-feb3-32c30429ceb3"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "bedroom", 3, 1, null, null, "", "" },
                    { new Guid("5d35a723-8143-ce4f-65a5-5f9c96bbc700"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "drawing-room", 4, 2, null, null, "", "" },
                    { new Guid("5de0bffc-9d84-a8c7-afa5-45553d4697bc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "kitchen", 3, 1, null, null, "", "" },
                    { new Guid("5df3dc41-fee2-5a2a-9d49-6cebf8fa820f"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("5e1475e7-3ff1-6ab6-9cbd-e358798c3fa8"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "living-room", 5, 2, null, null, "", "" },
                    { new Guid("5e5da46f-badf-8d4c-cf62-9904b636ea8c"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "living-room", 2, 4, null, null, "", "" },
                    { new Guid("5ef2210f-57a7-1105-b6e0-f9224caca4f4"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("60363b9f-5dd0-ece6-a2df-e749bef2833a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-7", "Hinged Wardrobe - 7'", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("61a6dabe-e3cc-1836-957d-a7eb21d66095"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "dining-room", 3, 2, null, null, "", "" },
                    { new Guid("61e26cbb-c5e1-649c-4505-2a9811f08491"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "base-units", "Base Units", 1, "utility", 0, 1, null, null, "", "" },
                    { new Guid("6351bed9-b05a-5e51-5c4d-af704a20f6e3"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-shelf-arch", "Breakfast Shelf / Arch", 1, "kitchen", 7, 1, null, null, "", "" },
                    { new Guid("638e4761-6072-08f1-aab0-0041f93048fa"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "iron-grills", "Iron Grills", 1, "utility", 8, 1, null, null, "", "" },
                    { new Guid("644ec65c-835e-d023-5588-df2ec4e7c842"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "master-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("65dd1a60-8c2c-38e8-c194-83a1c9bdc9d0"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "kitchen", 4, 4, null, null, "", "" },
                    { new Guid("66112245-6ae6-3904-e993-ce3ba60e79f1"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "main-door", 0, 1, null, null, "", "" },
                    { new Guid("667cd20f-8800-e523-2bc8-dfad3ae0a79c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "utility", 3, 1, null, null, "", "" },
                    { new Guid("67f2e3e7-5dda-d599-4b4d-dd3b2e34b94d"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-counter", "Breakfast Counter", 1, "kitchen", 6, 2, null, null, "", "" },
                    { new Guid("6984fc7c-644c-994d-f818-9325c0b4f29a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "bedroom", 8, 1, null, null, "", "" },
                    { new Guid("6a896d15-47f1-d156-4c5b-99b8dc2ad564"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units-glass", "Wall Units - Glass", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("6e2aa45e-1adf-c9ce-9104-4bcf2df15134"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "living-room", 6, 4, null, null, "", "" },
                    { new Guid("719ae3f7-fc1f-23b7-7d33-07e12c51e7d2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "kids-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("75923de7-fcd4-fe91-9adf-7a3ea72c3942"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "guest-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("7630dee6-46b1-5cc2-590d-1a1ee2ae311d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "master-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("764e059f-bb6c-a984-82c7-f7672fd68597"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-full-length", "Hinged Wardrobe - Full Length", 1, "guest-bedroom", 1, 1, null, null, "", "" },
                    { new Guid("78726f08-b71f-211b-dc2a-ab0bca436c8b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "drawing-room", 1, 1, null, null, "", "" },
                    { new Guid("796eeb5c-6e42-3367-83ac-2163aa0d21ff"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "kitchen", 5, 2, null, null, "", "" },
                    { new Guid("79927349-a349-97a8-5f86-d6c3f2d75cd6"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "puja-unit", "Puja Unit", 1, "dining-room", 10, 1, null, null, "", "" },
                    { new Guid("7b0dc5ad-f304-1551-2172-032e55d2706c"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "countertop", "Countertop", 1, "utility", 1, 2, null, null, "", "" },
                    { new Guid("7c185000-643e-a29f-3017-038e0013078c"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "dining-room", 4, 2, null, null, "", "" },
                    { new Guid("7e41fcff-80ae-2dc8-f04b-ab66e06b0c18"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "used-clothes-wardrobe", "Used Clothes Wardrobe", 1, "kids-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("7f574609-c9ca-36cf-787f-6f459e2a5d52"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "living-room", 1, 1, null, null, "", "" },
                    { new Guid("80280448-df52-4104-6688-5f1af5eb802e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-7", "Hinged Wardrobe - 7'", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("80c8a664-e7b7-883b-7b85-58a34d1c422e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling-paint", "False Ceiling + Paint", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("8181c1df-fb4f-7dc6-ffb7-e1ae4dcf7e1f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "drawing-room", 9, 1, null, null, "", "" },
                    { new Guid("821c5d1e-a83a-12b2-7760-fe3b7370f1aa"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "kids-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("82229ea7-8adb-e8e2-842a-cd3fe87e919e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "book-shelf-unit", "Book Shelf Unit", 1, "bedroom", 9, 1, null, null, "", "" },
                    { new Guid("82471455-3942-9a66-9932-1a468da1c11d"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "kids-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("82f733c5-4cad-066f-e058-cab9a3d65b16"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "master-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("83f953e6-2009-1d3e-5f74-e036190132f4"), 6500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accessories", "Accessories", 2, "utility", 0, 4, null, null, "", "" },
                    { new Guid("8401ef46-9c15-b76a-b74c-4de779c5ecc4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-full-height", "Sliding Wardrobe - Full Height", 1, "master-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("841aef44-1ddd-1a33-fa2b-7732a9423cbc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shelf", "Shelf", 1, "utility", 2, 1, null, null, "", "" },
                    { new Guid("86df2090-e0bd-e2a0-234c-1e0811bdb4d6"), 3500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tap", "Tap", 2, "kitchen", 9, 4, null, null, "", "" },
                    { new Guid("899fe62e-6a3a-a22d-575f-d514d3179e52"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "drawing-room", 8, 1, null, null, "", "" },
                    { new Guid("8a10ad0b-9333-ebd0-89cb-4bdf42620c6b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "used-clothes-wardrobe", "Used Clothes Wardrobe", 1, "master-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("8be61e4c-d228-7027-d031-f4085380e07a"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "dining-room", 8, 1, null, null, "", "" },
                    { new Guid("8e639e99-14ee-f94c-dd5a-bd1a99365c91"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "drawing-room", 2, 4, null, null, "", "" },
                    { new Guid("91195cd2-a496-0678-27ec-12bc6822dd75"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "living-room", 0, 2, null, null, "", "" },
                    { new Guid("923cfba9-c62d-fb61-2f75-6d7be663a64c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-glass-wardrobe", "Sliding Glass Wardrobe", 1, "bedroom", 4, 1, null, null, "", "" },
                    { new Guid("962b4f44-1fdb-0e4d-64fe-e210e1615133"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-7", "Sliding Wardrobe - 7'", 1, "master-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("96b52abc-4833-dfc4-9569-a07f1136b6ae"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "utility", 4, 1, null, null, "", "" },
                    { new Guid("96c21d8f-4d5e-c12e-46a3-5d54e8797e3a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-glass-wardrobe", "Sliding Glass Wardrobe", 1, "guest-bedroom", 4, 1, null, null, "", "" },
                    { new Guid("97389e71-44b7-c831-9270-2d829eae2f97"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling-paint", "False Ceiling + Paint", 1, "utility", 3, 1, null, null, "", "" },
                    { new Guid("97f8972c-a092-f0be-9013-98f1d0c23c14"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-glass-wardrobe", "Sliding Glass Wardrobe", 1, "master-bedroom", 4, 1, null, null, "", "" },
                    { new Guid("9adb633c-748f-36f8-9d4c-bb2219c79a51"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "utility", 7, 2, null, null, "", "" },
                    { new Guid("9e58dd5e-9b6e-0d07-681f-6bc85d3266b3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "living-room", 3, 2, null, null, "", "" },
                    { new Guid("9ef1a371-bc1f-231d-bbe7-2c74b68ea886"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "bedroom", 6, 1, null, null, "", "" },
                    { new Guid("a031da17-b68a-7bdc-ec52-bf206cfe0242"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "living-room", 6, 1, null, null, "", "" },
                    { new Guid("a0811a00-6b02-10ca-73be-bf8c5d41c14f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "drawing-room", 7, 1, null, null, "", "" },
                    { new Guid("a19feffa-3caa-be40-a662-32acfdc45e9e"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "living-room", 0, 4, null, null, "", "" },
                    { new Guid("a39cda8e-d15d-298a-dd80-8da9197c2538"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "book-shelf-unit", "Book Shelf Unit", 1, "kids-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("a5058cdf-ecdf-bfb6-5308-0dead6964a79"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "kids-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("a5dd2a73-9597-f88c-9775-aadb822e0b8c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-7", "Sliding Wardrobe - 7'", 1, "kids-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("aa3bda68-e2d4-3068-a505-88f4120e180e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "drawing-room", 0, 1, null, null, "", "" },
                    { new Guid("aab6f89c-e843-1b35-b534-0340afb56958"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-full-length", "Hinged Wardrobe - Full Length", 1, "master-bedroom", 1, 1, null, null, "", "" },
                    { new Guid("ab7ebfb2-a1f9-54a6-7947-17758cda7493"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "bedroom", 5, 1, null, null, "", "" },
                    { new Guid("ad113a72-c8be-31f1-e26e-48b25cd112f4"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "utility", 6, 4, null, null, "", "" },
                    { new Guid("b0ca6074-4698-59e5-b963-c24d43698f1e"), 45000m, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "security-door", "Security Door", 2, "main-door", 2, 4, null, null, "", "" },
                    { new Guid("b1d53729-a301-a75f-41c0-2b39c15cfa1f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "bedroom", 4, 2, null, null, "", "" },
                    { new Guid("b2a5cd57-6193-1661-950c-f4e720a6d58f"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "countertop", "Countertop", 1, "kitchen", 1, 2, null, null, "", "" },
                    { new Guid("b4be69ad-f526-6761-1231-1e7a12bc4921"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "living-room", 3, 2, null, null, "", "" },
                    { new Guid("b927da08-424a-d371-7a3a-9add9c4e5ae9"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "guest-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("bad39dd5-12fd-bc5c-595c-027c28e17abe"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "kids-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("bc7e4897-aeee-585a-0f4b-e46ce793ac3a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "bedroom", 10, 1, null, null, "", "" },
                    { new Guid("be0fadea-f6ef-d91b-1184-5a3cddf9acb9"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "kids-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("bf840905-dc70-1ad8-9bd8-8637282d806d"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "kitchen", 5, 2, null, null, "", "" },
                    { new Guid("bffa1014-1fb8-fb5b-8d98-41d845a0a4ab"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "living-room", 1, 4, null, null, "", "" },
                    { new Guid("c188ea3a-62cf-05fc-2ae2-11d94abc7077"), 1200m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cylinder-lights", "Cylinder Lights", 2, "utility", 5, 4, null, null, "", "" },
                    { new Guid("c24a32d5-add1-aef8-1361-9bcb8fabc695"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-full-height", "Sliding Wardrobe - Full Height", 1, "bedroom", 3, 1, null, null, "", "" },
                    { new Guid("c2d5d273-b4df-22cf-9177-c4b56d1aae94"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling-paint", "False Ceiling + Paint", 1, "drawing-room", 0, 1, null, null, "", "" },
                    { new Guid("c3a1bdc9-3c3d-12f7-6d36-34a6d2383dad"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units-wood", "Wall Units - Wood", 1, "kitchen", 1, 1, null, null, "", "" },
                    { new Guid("c5a7045f-bb33-022d-32b8-8a9345717beb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "guest-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("c5bd029f-2806-0fdf-28c9-3521f3bc9eeb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "drawing-room", 6, 2, null, null, "", "" },
                    { new Guid("c5d2811a-97a3-3d64-bac9-8496bf053330"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "drawing-room", 7, 2, null, null, "", "" },
                    { new Guid("c740437e-81ce-faff-52ff-c45f10dcf773"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "guest-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("c8b171ed-62c5-df8a-3197-dc554e96082d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "dining-room", 2, 4, null, null, "", "" },
                    { new Guid("cc634134-b741-99c2-829e-beff524f83aa"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "book-shelf-unit", "Book Shelf Unit", 1, "master-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("cc63ec8d-219b-2893-0f78-cec1624e419b"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-counter-arch", "Breakfast Counter - Arch", 1, "kitchen", 3, 2, null, null, "", "" },
                    { new Guid("cdfce94f-ebf4-fe1c-e2d3-96c01af760cb"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "main-door", 0, 1, null, null, "", "" },
                    { new Guid("ce978044-2182-a979-5ac0-b3c15d9d41f4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "appliance-unit", "Appliance Unit", 1, "kitchen", 5, 1, null, null, "", "" },
                    { new Guid("cff22365-2731-0058-de56-bd128d7753d9"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "dining-room", 7, 2, null, null, "", "" },
                    { new Guid("d01c435c-7ed0-122d-0af0-64c8b5e94036"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-7", "Hinged Wardrobe - 7'", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("d23572f3-ebb8-9b8b-e60d-163b6e3b0d08"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "dining-room", 4, 1, null, null, "", "" },
                    { new Guid("d2b03eef-c0e3-8d53-2203-33b16cee5aa1"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-glass-wardrobe", "Sliding Glass Wardrobe", 1, "kids-bedroom", 4, 1, null, null, "", "" },
                    { new Guid("d2b3e4e7-58bf-ac51-983a-acf2ed953cc3"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "puja-unit", "Puja Unit", 1, "drawing-room", 10, 1, null, null, "", "" },
                    { new Guid("d5553f43-cc56-c215-57ee-602107b10519"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("d56fd828-0874-9600-ace5-9f168b4332e0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shelves", "Shelves", 1, "kitchen", 4, 2, null, null, "", "" },
                    { new Guid("d59909e2-5bec-73e4-07c9-de1916f02865"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "puja-unit", "Puja Unit", 1, "living-room", 8, 1, null, null, "", "" },
                    { new Guid("d6fcbbf4-0dab-1568-b390-52d4e36d1555"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "guest-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("d7994bdf-8aaa-f09a-bd81-842638d4fe87"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "groove-shutters", "Groove Shutters", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("d99a7a31-f5b6-7478-b9ef-cb88eb8074e1"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "kids-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("d9a6a163-e750-4a82-e488-041a19fdf526"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "living-room", 4, 2, null, null, "", "" },
                    { new Guid("d9a7a2ac-b956-eecc-bcba-0a2fd6683461"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "bedroom", 1, 2, null, null, "", "" },
                    { new Guid("da029510-936a-7227-53bb-dece1d4fcd08"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dado-tiles", "Dado Tiles", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("daa51fc9-80c7-aa7a-3925-97f721d6aa51"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "dining-room", 3, 1, null, null, "", "" },
                    { new Guid("dd032887-46b3-fba3-4a12-f22a8cea451a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling-paint", "False Ceiling + Paint", 1, "kitchen", 3, 1, null, null, "", "" },
                    { new Guid("de766e20-051c-182a-0a9c-8107048e5e1c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "living-room", 1, 1, null, null, "", "" },
                    { new Guid("e6acb2fd-3503-7c2a-c8cb-47afacaf86e0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("e7700e15-640c-b4c9-d064-1b61834c0839"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-with-pu", "Rafters with PU", 1, "master-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("e8957cc0-d176-225c-60a3-ff555cfb403a"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "drawing-room", 0, 4, null, null, "", "" },
                    { new Guid("e93092f5-1aae-9caa-483c-82885328a2da"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "drawing-room", 4, 1, null, null, "", "" },
                    { new Guid("ea02028b-a0b4-223f-aab0-c36d0dda7778"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "utility", 1, 1, null, null, "", "" },
                    { new Guid("eab013ad-8df1-be19-9b27-bbc5d957ca4a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "guest-bedroom", 5, 1, null, null, "", "" },
                    { new Guid("ebc5b8c3-5309-84ab-8c61-b1071e7aa178"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "guest-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("ec2a685a-a7eb-2be8-ebb4-8c2869160d99"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "master-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("ec47aaea-43cb-bc0d-fef6-b0cf434498a1"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "drawing-room", 2, 4, null, null, "", "" },
                    { new Guid("ec524e45-8187-cb7a-12f2-8dfc4f1dd94c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "base-units", "Base Units", 1, "kitchen", 0, 1, null, null, "", "" },
                    { new Guid("ec666993-0123-490a-b342-48c565cec4fb"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "drawing-room", 5, 2, null, null, "", "" },
                    { new Guid("ec91f7ed-648f-2e7a-d2d1-b8bbfa3097c6"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "master-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("ed247d93-4c5c-a765-3782-19d64ac97007"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("efc95d44-33a2-cd55-ac1a-e75a17f01fb7"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "drawing-room", 3, 2, null, null, "", "" },
                    { new Guid("f15bcf85-18a9-10cb-1885-4473429bdfe8"), 48000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-table", "Dining Table", 2, "dining-room", 0, 4, null, null, "", "" },
                    { new Guid("f1aac86e-d833-343e-4eea-20c64edcd82e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sliding-wardrobe-full-height", "Sliding Wardrobe - Full Height", 1, "guest-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("f229ae58-264b-0ecb-9001-183f2b09585c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "hinged-wardrobe-full-length", "Hinged Wardrobe - Full Length", 1, "kids-bedroom", 1, 1, null, null, "", "" },
                    { new Guid("f2d55289-c2e8-981d-ef82-c278ca1ec982"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dado-tiles", "Dado Tiles", 1, "utility", 2, 1, null, null, "", "" },
                    { new Guid("f40bd7ad-23cf-f8da-a052-14f61ed198cc"), 6500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accessories", "Accessories", 2, "kitchen", 0, 4, null, null, "", "" },
                    { new Guid("f57fffdb-388c-20f2-6643-cb811b20ec89"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "dining-room", 6, 4, null, null, "", "" },
                    { new Guid("f6f6147e-197b-9e50-89ef-b4457a0a1171"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beadings", "Beadings", 1, "drawing-room", 5, 2, null, null, "", "" },
                    { new Guid("fa5b83e1-422a-7786-5769-5885c7e7f61b"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "living-room", 5, 1, null, null, "", "" },
                    { new Guid("fc49fc09-a6d1-11db-d85c-53f0d1a97093"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains-blind", "Curtains / Blind", 1, "living-room", 3, 1, null, null, "", "" },
                    { new Guid("fd3f6bfa-ad4f-9b21-886d-b7987dd98056"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "kids-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("fda2eb68-5cec-192d-05d1-6c7e041c9000"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pantry-unit", "Pantry Unit", 1, "utility", 4, 1, null, null, "", "" }
                });

            migrationBuilder.InsertData(
                table: "QuotationRates",
                columns: new[] { "Id", "CarcassMaterial", "CreatedAt", "CreatedByEmployeeId", "EffectiveFrom", "Finish", "IsActive", "ItemKey", "RatePerUnit", "ShutterMaterial", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey" },
                values: new object[,]
                {
                    { new Guid("10be9b96-df1c-c70d-82d6-36d6ba05ad06"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "curtains-blind", 450m, "", 1, null, null, "" },
                    { new Guid("1232ad1d-5bdf-78c1-0d7b-2673e23d75fd"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "false-ceiling-paint", 260m, "", 1, null, null, "" },
                    { new Guid("1fdcd5ee-551a-3ee2-73ad-afb9c8f3220f"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "accent-wall-wallpaper", 900m, "", 1, null, null, "" },
                    { new Guid("2b828d10-595a-28ff-2f34-9dd0706d9d72"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-counter", 2800m, "", 2, null, null, "" },
                    { new Guid("2d838be9-d478-3405-f757-d7290e7bda01"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "hinged-wardrobe-7", 1850m, "", 1, null, null, "" },
                    { new Guid("3010b2eb-1e7c-5b09-a2bd-4ed8340486a3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "magnetic-track-lights", 900m, "", 2, null, null, "" },
                    { new Guid("3a833d35-3b9f-9a18-9090-4e67f76b1212"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "console-unit", 1500m, "", 1, null, null, "" },
                    { new Guid("41fb8878-6148-1058-8c99-2740858e1643"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "cob-lights", 450m, "", 2, null, null, "" },
                    { new Guid("441f9e7c-d494-135d-6eb3-604d0976108c"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Glass", true, "wall-units-glass", 3800m, "Profile", 1, null, null, "" },
                    { new Guid("476f7e9c-8a17-8d78-08c4-67e07f199b14"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Acrylic", true, "base-units", 4200m, "HDHMR", 1, null, null, "" },
                    { new Guid("491ad005-b75e-1713-29ca-4f0823b07782"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "base-units", 3800m, "", 1, null, null, "" },
                    { new Guid("4ac9b703-7002-8830-5e82-a5ebe00c2076"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3200m, "", 1, null, null, "" },
                    { new Guid("4eee92db-72fb-973e-5828-103843f6fd03"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "study-table-wall-storage", 2200m, "", 1, null, null, "" },
                    { new Guid("56cce40c-30cc-98bd-e81b-cfb477f0d48e"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "beadings", 350m, "", 2, null, null, "" },
                    { new Guid("57ff7bbb-b149-d21f-1fcb-4c80e4cd1831"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "iron-grills", 900m, "", 1, null, null, "" },
                    { new Guid("5b356221-fb2c-4fd5-44fd-d35dd2d98ffe"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "partition", 1400m, "", 1, null, null, "" },
                    { new Guid("659b20fe-44fb-7f03-7776-1a1a671fc1e7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "cove-lights", 500m, "", 2, null, null, "" },
                    { new Guid("6803170d-8ea6-eab2-a455-26939292b0df"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "loft", 2400m, "", 1, null, null, "" },
                    { new Guid("73a15172-629f-fd0c-162e-099dd0198d22"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "appliance-unit", 3900m, "", 1, null, null, "" },
                    { new Guid("7b373dc4-da2c-0251-405d-c2ddbd0fed92"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "profile-lights", 550m, "", 2, null, null, "" },
                    { new Guid("7eac4e58-b2b5-3b36-2528-41fc0415a061"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "sliding-glass-wardrobe", 2600m, "", 1, null, null, "" },
                    { new Guid("83ede644-d453-7a56-19d0-f90f6afe5557"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "hinged-wardrobe-full-length", 2000m, "", 1, null, null, "" },
                    { new Guid("880210e8-938a-0e6f-bf09-e01db6d54248"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shelves", 900m, "", 2, null, null, "" },
                    { new Guid("8e95c806-ab37-124d-d3ff-49d0418160f9"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "sliding-wardrobe-7", 2150m, "", 1, null, null, "" },
                    { new Guid("90349a64-5575-9a05-b69b-c8332c8ea820"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "storage-unit", 1600m, "", 1, null, null, "" },
                    { new Guid("92008837-3245-a48a-108d-767b986c1eea"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tv-unit", 2400m, "", 2, null, null, "" },
                    { new Guid("92848537-46f9-10d7-856d-c01b70f33a8c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "groove-shutters", 1400m, "", 1, null, null, "" },
                    { new Guid("9b7909a2-c88f-cd6a-3a50-a3474e59efc4"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "puja-unit", 2600m, "", 1, null, null, "" },
                    { new Guid("a2398635-9f8b-3675-1d1b-579cfadbbee3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "book-shelf-unit", 1900m, "", 1, null, null, "" },
                    { new Guid("a62516ce-ebc8-4f01-00e7-83eb45110896"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wooden-ceiling", 850m, "", 1, null, null, "" },
                    { new Guid("a85d7071-2018-d672-54aa-8ee948bcc808"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "arch", 1100m, "", 2, null, null, "" },
                    { new Guid("b22dedb9-6a5c-205b-4798-8a293994f9dc"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "janitor-unit", 2200m, "", 1, null, null, "" },
                    { new Guid("b2691756-7e84-e535-4241-1c1d1375f56d"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "countertop", 1600m, "", 2, null, null, "" },
                    { new Guid("b376f7d5-65dd-8dc3-1cfa-a5d5f268057e"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shelf", 1800m, "", 1, null, null, "" },
                    { new Guid("b57bd4b3-0775-4c0f-910d-7597a21851f6"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "sliding-wardrobe-full-height", 2300m, "", 1, null, null, "" },
                    { new Guid("b746c184-5916-7887-30b6-a136003aa396"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "ms-rods", 600m, "", 2, null, null, "" },
                    { new Guid("b7ab1d69-696b-c3be-b382-8ba53b242051"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "mosquito-mesh", 350m, "", 1, null, null, "" },
                    { new Guid("b8adefb1-cf01-d8e4-f82e-124efdb556ec"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "study-table", 2600m, "", 2, null, null, "" },
                    { new Guid("bd013877-6bae-5103-653a-c183d61f15d3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units-wood", 3200m, "", 1, null, null, "" },
                    { new Guid("bd146a42-1ad0-a93e-e2af-200ae9012620"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "crockery-unit", 1950m, "", 1, null, null, "" },
                    { new Guid("c089fb2a-c8d0-1f12-e038-0c5708d1ddeb"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bar-unit", 2000m, "", 1, null, null, "" },
                    { new Guid("cde5cf7a-9e41-e9ce-feae-ac7947050c48"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "accent-wall-paneling", 1300m, "", 1, null, null, "" },
                    { new Guid("cee6314a-963f-071c-503f-990ae2a329de"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-shelf-arch", 2600m, "", 1, null, null, "" },
                    { new Guid("cfdcef94-4404-99b0-69ec-246e26279b3a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "seating-unit", 2100m, "", 1, null, null, "" },
                    { new Guid("d1c29723-c5bd-caad-5697-3d56289f624a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "used-clothes-wardrobe", 1700m, "", 1, null, null, "" },
                    { new Guid("d439a14c-12c6-7670-48c5-c768e369de37"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rafters-with-pu", 1250m, "", 2, null, null, "" },
                    { new Guid("d47cc528-0b8c-e26b-54a9-0f952eb83ef2"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units-glass", 3400m, "", 1, null, null, "" },
                    { new Guid("d72bca15-4c66-e19f-7b55-acb3ce344e7f"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bay-window-paneling", 1350m, "", 1, null, null, "" },
                    { new Guid("dfdf5dd0-340a-4e03-6d55-34d8e73e2ae1"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "main-door-paneling", 1800m, "", 1, null, null, "" },
                    { new Guid("eaa29145-a723-bedd-16fb-c8e0ea4f1efb"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shoe-rack", 1600m, "", 1, null, null, "" },
                    { new Guid("ed9d2c08-8272-6a4f-88a6-269f751d6de0"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Acrylic", true, "wall-units-wood", 3600m, "HDHMR", 1, null, null, "" },
                    { new Guid("f0ac0253-20ff-9a46-b577-e138ca5be7a3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-counter-arch", 1200m, "", 2, null, null, "" },
                    { new Guid("f5a07e95-6d46-21e2-2a2c-76a26019bd1c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "fluted-panel", 1200m, "", 1, null, null, "" },
                    { new Guid("fe099268-dc39-60b3-d0f2-134379be492a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dado-tiles", 220m, "", 1, null, null, "" },
                    { new Guid("fe969f8e-759e-a927-f8c0-acbde10f7089"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "pantry-unit", 3600m, "", 1, null, null, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("02fffa74-1d59-4a05-00ac-949494c07c15"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("04a9b948-028e-ab01-db09-9fb7f6fe3b53"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("05394ad6-9744-88b4-943c-87cd2a103943"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("05668faa-83ad-ddd8-3e52-b27a2c3c3b02"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("060a4f02-7324-1663-eea6-8ac6012f66df"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("065e91ef-d7ee-24da-609d-f34dbb6f2cc5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("08166876-f97b-2de3-263b-7c1060c3731b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("08944344-7be1-6505-74ab-936681def752"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("097375b5-4414-1cd4-789a-298b3c3f6599"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0a0b3520-291f-45a8-3882-21e51cccc38b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0b2c1fb9-6b8c-c88a-0171-b56ec7b6d608"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0be8f9e8-a419-dc7f-ae2c-fa258c97a405"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("0dfa32cb-18d6-323a-346e-c1ec0d4c31c3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("131f0c03-07c7-8a3c-3f17-12096c4502f1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1346bb22-4ae6-0542-2458-8a79498a2865"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("166654ee-5c10-2652-8445-0f8370e8b15a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("18f6a19e-f937-2e0b-19c1-1e53d49d9356"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1993cf73-f1c9-cced-0407-2be02cfda20a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("19eb86f4-3aed-e77f-6424-943c1d4e0ca9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1a1143a9-2c71-5e68-79f6-630d0b9adfd0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1b662243-588c-8afd-1a80-c00a89695702"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1bce4df8-f075-6edb-ea0e-c863b6383a6f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1d2b4836-8ce7-66a7-3ca1-fd3c5801c40a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1d9b86f5-bd70-7f91-8198-c09cb60d4683"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("1e2cb815-e2d0-9a73-8d7a-264ba795e822"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("20c27454-8fa5-e2fb-847f-652bb8d2527c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("21d67a95-c5db-42b4-ffba-c7135b2a4dff"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("24b2577b-01d9-a738-f1bb-d5a312bf8894"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("24d26859-44c4-8bae-759b-8344704aad29"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("28631194-80bf-904b-4d0b-fe6f900523a9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2930f2c1-63a3-40a5-42b4-6ddb9f8ad2a6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2b1ec648-2c59-8c6c-d9c4-c477bd90cfeb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2d8905f6-239e-4c1c-7990-5ccac4652f85"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2f011022-a52f-159f-2953-60f0b4ef1c50"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("2f97731e-48c9-b112-de29-3529a5551329"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("34e549e9-242a-609c-734d-2e2d196e51d0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("37ae8eb8-3f23-84c0-8de6-7163f93c7438"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("38a8aed6-3726-9e07-a6f5-2f16b048a5f5"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("38ce5749-64a9-91c7-d4d4-bbd9a34f3217"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3974fdaa-350f-7af0-feb4-eea95ca04525"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3ad3aa4b-5b87-d5b4-a593-3f5957ba578c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3b74d71f-4f35-b548-6e00-1b4551d015ba"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3befd059-4953-b414-39f7-bfbec0e44327"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3c802de9-3573-057e-0cbc-f79a51d36bfd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("3e90cda2-8f2c-6c07-7f59-8d98dd9689fb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("41183445-01de-1054-2916-412e92884c15"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("446b5b81-f658-b07c-dffc-70fa118422dd"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4540cb65-aca0-7e9d-7888-883fdfa2d7c1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("456eaeac-73e7-0d1c-4afe-ebcc2476962c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("47ca1e7a-4fc6-c4d9-74ed-efa9f1ac0edb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("489198b5-c376-8b27-fc5b-5a6c312bd567"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("4c6cfc0e-2066-50c1-e695-8dc98438dd93"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5135daba-b0aa-982b-7057-e539d89a2d02"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5563f0c3-4762-6576-f908-e9828bdb1f73"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("585c5a6f-cf25-c39f-a844-4144f97f551a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("58c91a09-c2e1-928b-2bcb-138f57b924f9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("58d22483-3a6c-30b0-feb3-32c30429ceb3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5d35a723-8143-ce4f-65a5-5f9c96bbc700"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5de0bffc-9d84-a8c7-afa5-45553d4697bc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5df3dc41-fee2-5a2a-9d49-6cebf8fa820f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5e1475e7-3ff1-6ab6-9cbd-e358798c3fa8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5e5da46f-badf-8d4c-cf62-9904b636ea8c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("5ef2210f-57a7-1105-b6e0-f9224caca4f4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("60363b9f-5dd0-ece6-a2df-e749bef2833a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("61a6dabe-e3cc-1836-957d-a7eb21d66095"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("61e26cbb-c5e1-649c-4505-2a9811f08491"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6351bed9-b05a-5e51-5c4d-af704a20f6e3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("638e4761-6072-08f1-aab0-0041f93048fa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("644ec65c-835e-d023-5588-df2ec4e7c842"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("65dd1a60-8c2c-38e8-c194-83a1c9bdc9d0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("66112245-6ae6-3904-e993-ce3ba60e79f1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("667cd20f-8800-e523-2bc8-dfad3ae0a79c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("67f2e3e7-5dda-d599-4b4d-dd3b2e34b94d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6984fc7c-644c-994d-f818-9325c0b4f29a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6a896d15-47f1-d156-4c5b-99b8dc2ad564"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("6e2aa45e-1adf-c9ce-9104-4bcf2df15134"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("719ae3f7-fc1f-23b7-7d33-07e12c51e7d2"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("75923de7-fcd4-fe91-9adf-7a3ea72c3942"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7630dee6-46b1-5cc2-590d-1a1ee2ae311d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("764e059f-bb6c-a984-82c7-f7672fd68597"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("78726f08-b71f-211b-dc2a-ab0bca436c8b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("796eeb5c-6e42-3367-83ac-2163aa0d21ff"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("79927349-a349-97a8-5f86-d6c3f2d75cd6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7b0dc5ad-f304-1551-2172-032e55d2706c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7c185000-643e-a29f-3017-038e0013078c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7e41fcff-80ae-2dc8-f04b-ab66e06b0c18"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("7f574609-c9ca-36cf-787f-6f459e2a5d52"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("80280448-df52-4104-6688-5f1af5eb802e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("80c8a664-e7b7-883b-7b85-58a34d1c422e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8181c1df-fb4f-7dc6-ffb7-e1ae4dcf7e1f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("821c5d1e-a83a-12b2-7760-fe3b7370f1aa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("82229ea7-8adb-e8e2-842a-cd3fe87e919e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("82471455-3942-9a66-9932-1a468da1c11d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("82f733c5-4cad-066f-e058-cab9a3d65b16"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("83f953e6-2009-1d3e-5f74-e036190132f4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8401ef46-9c15-b76a-b74c-4de779c5ecc4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("841aef44-1ddd-1a33-fa2b-7732a9423cbc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("86df2090-e0bd-e2a0-234c-1e0811bdb4d6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("899fe62e-6a3a-a22d-575f-d514d3179e52"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8a10ad0b-9333-ebd0-89cb-4bdf42620c6b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8be61e4c-d228-7027-d031-f4085380e07a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("8e639e99-14ee-f94c-dd5a-bd1a99365c91"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("91195cd2-a496-0678-27ec-12bc6822dd75"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("923cfba9-c62d-fb61-2f75-6d7be663a64c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("962b4f44-1fdb-0e4d-64fe-e210e1615133"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("96b52abc-4833-dfc4-9569-a07f1136b6ae"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("96c21d8f-4d5e-c12e-46a3-5d54e8797e3a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("97389e71-44b7-c831-9270-2d829eae2f97"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("97f8972c-a092-f0be-9013-98f1d0c23c14"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9adb633c-748f-36f8-9d4c-bb2219c79a51"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9e58dd5e-9b6e-0d07-681f-6bc85d3266b3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("9ef1a371-bc1f-231d-bbe7-2c74b68ea886"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a031da17-b68a-7bdc-ec52-bf206cfe0242"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a0811a00-6b02-10ca-73be-bf8c5d41c14f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a19feffa-3caa-be40-a662-32acfdc45e9e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a39cda8e-d15d-298a-dd80-8da9197c2538"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a5058cdf-ecdf-bfb6-5308-0dead6964a79"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("a5dd2a73-9597-f88c-9775-aadb822e0b8c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("aa3bda68-e2d4-3068-a505-88f4120e180e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("aab6f89c-e843-1b35-b534-0340afb56958"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ab7ebfb2-a1f9-54a6-7947-17758cda7493"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ad113a72-c8be-31f1-e26e-48b25cd112f4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b0ca6074-4698-59e5-b963-c24d43698f1e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b1d53729-a301-a75f-41c0-2b39c15cfa1f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b2a5cd57-6193-1661-950c-f4e720a6d58f"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b4be69ad-f526-6761-1231-1e7a12bc4921"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("b927da08-424a-d371-7a3a-9add9c4e5ae9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bad39dd5-12fd-bc5c-595c-027c28e17abe"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bc7e4897-aeee-585a-0f4b-e46ce793ac3a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("be0fadea-f6ef-d91b-1184-5a3cddf9acb9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bf840905-dc70-1ad8-9bd8-8637282d806d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("bffa1014-1fb8-fb5b-8d98-41d845a0a4ab"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c188ea3a-62cf-05fc-2ae2-11d94abc7077"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c24a32d5-add1-aef8-1361-9bcb8fabc695"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c2d5d273-b4df-22cf-9177-c4b56d1aae94"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c3a1bdc9-3c3d-12f7-6d36-34a6d2383dad"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5a7045f-bb33-022d-32b8-8a9345717beb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5bd029f-2806-0fdf-28c9-3521f3bc9eeb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5d2811a-97a3-3d64-bac9-8496bf053330"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c740437e-81ce-faff-52ff-c45f10dcf773"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("c8b171ed-62c5-df8a-3197-dc554e96082d"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cc634134-b741-99c2-829e-beff524f83aa"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cc63ec8d-219b-2893-0f78-cec1624e419b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cdfce94f-ebf4-fe1c-e2d3-96c01af760cb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ce978044-2182-a979-5ac0-b3c15d9d41f4"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("cff22365-2731-0058-de56-bd128d7753d9"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d01c435c-7ed0-122d-0af0-64c8b5e94036"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d23572f3-ebb8-9b8b-e60d-163b6e3b0d08"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2b03eef-c0e3-8d53-2203-33b16cee5aa1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2b3e4e7-58bf-ac51-983a-acf2ed953cc3"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d5553f43-cc56-c215-57ee-602107b10519"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d56fd828-0874-9600-ace5-9f168b4332e0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d59909e2-5bec-73e4-07c9-de1916f02865"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d6fcbbf4-0dab-1568-b390-52d4e36d1555"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d7994bdf-8aaa-f09a-bd81-842638d4fe87"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d99a7a31-f5b6-7478-b9ef-cb88eb8074e1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d9a6a163-e750-4a82-e488-041a19fdf526"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("d9a7a2ac-b956-eecc-bcba-0a2fd6683461"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("da029510-936a-7227-53bb-dece1d4fcd08"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("daa51fc9-80c7-aa7a-3925-97f721d6aa51"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("dd032887-46b3-fba3-4a12-f22a8cea451a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("de766e20-051c-182a-0a9c-8107048e5e1c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e6acb2fd-3503-7c2a-c8cb-47afacaf86e0"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e7700e15-640c-b4c9-d064-1b61834c0839"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e8957cc0-d176-225c-60a3-ff555cfb403a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("e93092f5-1aae-9caa-483c-82885328a2da"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ea02028b-a0b4-223f-aab0-c36d0dda7778"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("eab013ad-8df1-be19-9b27-bbc5d957ca4a"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ebc5b8c3-5309-84ab-8c61-b1071e7aa178"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec2a685a-a7eb-2be8-ebb4-8c2869160d99"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec47aaea-43cb-bc0d-fef6-b0cf434498a1"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec524e45-8187-cb7a-12f2-8dfc4f1dd94c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec666993-0123-490a-b342-48c565cec4fb"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ec91f7ed-648f-2e7a-d2d1-b8bbfa3097c6"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("ed247d93-4c5c-a765-3782-19d64ac97007"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("efc95d44-33a2-cd55-ac1a-e75a17f01fb7"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f15bcf85-18a9-10cb-1885-4473429bdfe8"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f1aac86e-d833-343e-4eea-20c64edcd82e"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f229ae58-264b-0ecb-9001-183f2b09585c"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f2d55289-c2e8-981d-ef82-c278ca1ec982"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f40bd7ad-23cf-f8da-a052-14f61ed198cc"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f57fffdb-388c-20f2-6643-cb811b20ec89"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("f6f6147e-197b-9e50-89ef-b4457a0a1171"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fa5b83e1-422a-7786-5769-5885c7e7f61b"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fc49fc09-a6d1-11db-d85c-53f0d1a97093"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fd3f6bfa-ad4f-9b21-886d-b7987dd98056"));

            migrationBuilder.DeleteData(
                table: "QuotationCatalogEntries",
                keyColumn: "Id",
                keyValue: new Guid("fda2eb68-5cec-192d-05d1-6c7e041c9000"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("10be9b96-df1c-c70d-82d6-36d6ba05ad06"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("1232ad1d-5bdf-78c1-0d7b-2673e23d75fd"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("1fdcd5ee-551a-3ee2-73ad-afb9c8f3220f"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("2b828d10-595a-28ff-2f34-9dd0706d9d72"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("2d838be9-d478-3405-f757-d7290e7bda01"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3010b2eb-1e7c-5b09-a2bd-4ed8340486a3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("3a833d35-3b9f-9a18-9090-4e67f76b1212"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("41fb8878-6148-1058-8c99-2740858e1643"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("441f9e7c-d494-135d-6eb3-604d0976108c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("476f7e9c-8a17-8d78-08c4-67e07f199b14"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("491ad005-b75e-1713-29ca-4f0823b07782"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4ac9b703-7002-8830-5e82-a5ebe00c2076"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("4eee92db-72fb-973e-5828-103843f6fd03"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("56cce40c-30cc-98bd-e81b-cfb477f0d48e"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("57ff7bbb-b149-d21f-1fcb-4c80e4cd1831"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("5b356221-fb2c-4fd5-44fd-d35dd2d98ffe"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("659b20fe-44fb-7f03-7776-1a1a671fc1e7"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("6803170d-8ea6-eab2-a455-26939292b0df"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("73a15172-629f-fd0c-162e-099dd0198d22"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("7b373dc4-da2c-0251-405d-c2ddbd0fed92"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("7eac4e58-b2b5-3b36-2528-41fc0415a061"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("83ede644-d453-7a56-19d0-f90f6afe5557"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("880210e8-938a-0e6f-bf09-e01db6d54248"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("8e95c806-ab37-124d-d3ff-49d0418160f9"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("90349a64-5575-9a05-b69b-c8332c8ea820"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("92008837-3245-a48a-108d-767b986c1eea"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("92848537-46f9-10d7-856d-c01b70f33a8c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("9b7909a2-c88f-cd6a-3a50-a3474e59efc4"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a2398635-9f8b-3675-1d1b-579cfadbbee3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a62516ce-ebc8-4f01-00e7-83eb45110896"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("a85d7071-2018-d672-54aa-8ee948bcc808"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b22dedb9-6a5c-205b-4798-8a293994f9dc"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b2691756-7e84-e535-4241-1c1d1375f56d"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b376f7d5-65dd-8dc3-1cfa-a5d5f268057e"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b57bd4b3-0775-4c0f-910d-7597a21851f6"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b746c184-5916-7887-30b6-a136003aa396"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b7ab1d69-696b-c3be-b382-8ba53b242051"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("b8adefb1-cf01-d8e4-f82e-124efdb556ec"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("bd013877-6bae-5103-653a-c183d61f15d3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("bd146a42-1ad0-a93e-e2af-200ae9012620"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("c089fb2a-c8d0-1f12-e038-0c5708d1ddeb"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("cde5cf7a-9e41-e9ce-feae-ac7947050c48"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("cee6314a-963f-071c-503f-990ae2a329de"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("cfdcef94-4404-99b0-69ec-246e26279b3a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d1c29723-c5bd-caad-5697-3d56289f624a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d439a14c-12c6-7670-48c5-c768e369de37"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d47cc528-0b8c-e26b-54a9-0f952eb83ef2"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("d72bca15-4c66-e19f-7b55-acb3ce344e7f"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("dfdf5dd0-340a-4e03-6d55-34d8e73e2ae1"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("eaa29145-a723-bedd-16fb-c8e0ea4f1efb"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("ed9d2c08-8272-6a4f-88a6-269f751d6de0"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("f0ac0253-20ff-9a46-b577-e138ca5be7a3"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("f5a07e95-6d46-21e2-2a2c-76a26019bd1c"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("fe099268-dc39-60b3-d0f2-134379be492a"));

            migrationBuilder.DeleteData(
                table: "QuotationRates",
                keyColumn: "Id",
                keyValue: new Guid("fe969f8e-759e-a927-f8c0-acbde10f7089"));

            migrationBuilder.InsertData(
                table: "QuotationCatalogEntries",
                columns: new[] { "Id", "BasePrice", "CategoryKey", "CategoryName", "CreatedAt", "CreatedByEmployeeId", "IsActive", "ItemKey", "ItemName", "PricingType", "RoomKey", "SortOrder", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey", "VariantName" },
                values: new object[,]
                {
                    { new Guid("016423b5-c35f-e21b-7e20-e812da7325bc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "master-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("02f9a7b1-e4a1-8608-f313-1b207e76ace8"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "drawing-room", 7, 1, null, null, "", "" },
                    { new Guid("091f22b0-0eee-e0e9-f917-fe04bd025644"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "living-room", 4, 2, null, null, "", "" },
                    { new Guid("0953a34b-dc99-041d-e996-c5a2ced7da0c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "arch", "Arch", 1, "kitchen", 0, 2, null, null, "", "" },
                    { new Guid("0ca90629-5d85-3933-6bfc-1b6601e65e84"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "kids-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("0f3c6702-2d92-f9ef-b3c7-d210e291d830"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "drawing-room", 4, 1, null, null, "", "" },
                    { new Guid("1291e7ad-d1ba-2ace-3786-8917e9275dc6"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "drawing-room", 6, 4, null, null, "", "" },
                    { new Guid("15d9a239-d43c-98b1-fa1f-1bfca0ee1c42"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("17347ad8-5fa8-9f04-2beb-cf2a52fb9999"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "drawing-room", 7, 2, null, null, "", "" },
                    { new Guid("17452e4a-7a23-d622-14e1-e5a5010ac2bd"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("1855560f-2d0d-6e9d-108a-8ae6977f9d46"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "guest-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("19a2638d-e298-19bd-abce-0eb2a56f0b46"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "living-room", 8, 1, null, null, "", "" },
                    { new Guid("1aef18cc-f26e-83fe-9915-8971a1c6c2b4"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "drawing-room", 9, 1, null, null, "", "" },
                    { new Guid("1bffd968-e2a8-1c80-490f-78b2a1c0aabc"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "main-door-paneling", "Main Door Paneling", 1, "main-door", 1, 1, null, null, "", "" },
                    { new Guid("1c9b3e4d-3b9a-0ec4-b172-7fa545748b99"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "master-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("1cda3973-15fb-46ca-86d9-29f0e279fef2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("1ce6193a-a9fd-19ff-7057-a9169cf66160"), 3500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tap", "Tap", 2, "kitchen", 9, 4, null, null, "", "" },
                    { new Guid("1eeb8297-0939-ee4d-2be8-89b6f3ddc3d2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "dining-room", 7, 1, null, null, "", "" },
                    { new Guid("1f97773b-fcbe-3926-095a-22ee342bd62d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "bedroom", 2, 1, null, null, "", "" },
                    { new Guid("1fe4f814-271c-70fa-23f1-e7707ee193df"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "guest-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("223779c5-73c7-361f-d324-d66bd0e20014"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("22951f32-f082-b8e8-a4ed-d3ea4979a74f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("22c76a62-b35c-02fc-0e07-359582a6171e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "dining-room", 5, 2, null, null, "", "" },
                    { new Guid("240cbf98-39c9-fbd3-4c40-1eed428c5c1f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "living-room", 7, 1, null, null, "", "" },
                    { new Guid("24717e96-f282-0d36-7cd2-f0a3b9a3d5a5"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "dining-room", 4, 1, null, null, "", "" },
                    { new Guid("25e1317b-1c2a-570c-c8e3-34f94abb3e03"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "guest-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("2836ef4d-ecd9-b771-5061-8672ea3e8287"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "kids-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("286d4e16-cf3e-c089-e342-61e75382429b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "bedroom", 2, 2, null, null, "", "" },
                    { new Guid("2b53036f-c0b1-4a71-d123-09e8f5695148"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shelf", "Shelf", 1, "utility", 2, 1, null, null, "", "" },
                    { new Guid("2ce11485-fdaf-9dc1-91ee-0ea19165aa9f"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "living-room", 5, 2, null, null, "", "" },
                    { new Guid("2ff3f8ce-627b-2337-6792-8c8a64ac9044"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "kids-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("303cd321-4595-46f5-0236-1bbb7dfeb879"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "living-room", 2, 4, null, null, "", "" },
                    { new Guid("32857d4e-2041-198d-bb44-355a1f80ea94"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "drawing-room", 5, 2, null, null, "", "" },
                    { new Guid("351a6ffc-2c38-8592-5405-9d2a79c5fe38"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "bedroom", 6, 1, null, null, "", "" },
                    { new Guid("37fd4d57-1904-7218-5390-7e318efdbb99"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("39fb1839-45ff-abd7-d967-7845f7a06788"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "kids-bedroom", 1, 4, null, null, "", "" },
                    { new Guid("3f648144-247f-d771-fb18-687228688a4a"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "bedroom", 7, 2, null, null, "", "" },
                    { new Guid("3f704865-0dc4-225c-5ddf-7043c990cc05"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "living-room", 0, 2, null, null, "", "" },
                    { new Guid("452abcad-7508-04ad-a2bb-72ea868e2d1a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("46a9918f-5e5c-a1be-a3fe-16e57e20002b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dado-tiles", "Dado Tiles", 1, "utility", 2, 1, null, null, "", "" },
                    { new Guid("480c3993-eb4a-2f69-cdf3-35024c734d15"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "ms-rods", "MS Rods", 1, "kitchen", 5, 2, null, null, "", "" },
                    { new Guid("486890cb-0291-5c20-4bd4-0b0debc2859f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "guest-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("4a48413f-e62f-fa9c-2bdc-92461169ffd8"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "dining-room", 6, 2, null, null, "", "" },
                    { new Guid("4ab483d7-1b47-0059-9638-ca42b00ba91a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "living-room", 3, 2, null, null, "", "" },
                    { new Guid("4c7481c0-4dbe-1e7b-323d-615e27c0679e"), 8500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sink", "Sink", 2, "kitchen", 8, 4, null, null, "", "" },
                    { new Guid("4e1c667d-5fd0-b57c-6dd7-8b65890d2b86"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "utility", 1, 1, null, null, "", "" },
                    { new Guid("4e671144-e82e-5c3a-a732-250121616d20"), 45000m, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "security-door", "Security Door", 2, "main-door", 2, 4, null, null, "", "" },
                    { new Guid("54552d0a-f321-f6d2-4a2a-6c4cf64c8c5e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dado-tiles", "Dado Tiles", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("54a33f97-e744-65f6-9f16-9d83900b66b3"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "kitchen", 1, 1, null, null, "wooden", "Wooden" },
                    { new Guid("5538bf6b-afc0-afab-5159-c7aac6e76d26"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "dining-room", 3, 1, null, null, "", "" },
                    { new Guid("5576888d-a8a0-fcba-dc2c-d273aa73c9f3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "guest-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("55ef0364-6f94-613f-277c-2e1795963a50"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "dining-room", 4, 2, null, null, "", "" },
                    { new Guid("561a8fa6-6a2b-b3b6-85c5-310380c67f6d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "master-bedroom", 1, 4, null, null, "", "" },
                    { new Guid("56241518-5690-f55e-eede-d4298bdada13"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-units", "Wall Units", 1, "kitchen", 2, 1, null, null, "glass", "Glass" },
                    { new Guid("5725bcff-8ca4-80b5-0b61-c36373ed57df"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("5bbeb36d-f8a8-ee18-4187-3dc617f8ce25"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "dining-room", 2, 4, null, null, "", "" },
                    { new Guid("5bebe991-bb98-0bd6-d6fa-0a5f82e2e8c2"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("5cf5c534-1f07-18c3-c03a-f0df0944317e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "bedroom", 3, 1, null, null, "", "" },
                    { new Guid("5d281df7-bebf-99f2-c42c-f2d822f3f0e3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "main-door", 0, 1, null, null, "", "" },
                    { new Guid("5d85aa51-829b-6a0c-5a56-ced0f93d4e2e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "drawing-room", 8, 1, null, null, "", "" },
                    { new Guid("5e23fe87-ca6d-56f2-5f97-f65552f690d2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "guest-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("5eb679f7-04fd-f0e9-c627-852f3d4d549c"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "kitchen", 4, 4, null, null, "", "" },
                    { new Guid("5ed00924-d3f8-1ddf-e27f-13009532f681"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("5f663cb3-ee93-2538-7666-1de74b24e339"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "living-room", 0, 4, null, null, "", "" },
                    { new Guid("5ffa552d-2da7-5c8e-6e2b-5d7c9b7d52de"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tall-unit", "Tall Unit", 1, "utility", 4, 1, null, null, "pantry", "Pantry" },
                    { new Guid("6069a039-958a-c47a-db27-d33a214fc65f"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "dining-room", 3, 2, null, null, "", "" },
                    { new Guid("60e3c213-a7c1-660c-b4dd-9e2b16e14616"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "master-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("60ed067c-b4c1-ae35-f7e4-02d76fc80ed3"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "bedroom", 3, 1, null, null, "", "" },
                    { new Guid("613ada14-2a82-3c4f-e507-c04931f782cc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-shelf", "Breakfast Shelf / Arch", 1, "kitchen", 7, 1, null, null, "", "" },
                    { new Guid("61e6bba7-2a87-10e4-18ac-04eb694c3f34"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "countertop", "Countertop", 1, "utility", 1, 2, null, null, "", "" },
                    { new Guid("63f0e8cb-7119-1a2f-fd52-4b9f2576dd59"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "jali-partition", "Jali / Partition", 1, "", 2, 1, null, null, "", "" },
                    { new Guid("64d317a0-a4d0-81f1-3025-9bb1db45a6e7"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("66be3a86-7410-cf9f-1fd0-3a52ad895543"), 1200m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cylinder-lights", "Cylinder Lights", 2, "utility", 5, 4, null, null, "", "" },
                    { new Guid("67646666-bf67-3eb3-5876-e9a9655c0d11"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "shoe-rack", "Shoe Rack", 1, "main-door", 0, 1, null, null, "", "" },
                    { new Guid("681b0348-772d-2600-1435-a04f3673999a"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "living-room", 6, 4, null, null, "", "" },
                    { new Guid("6cb7f51d-625e-2229-c95b-e6585577c361"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "master-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("6d0c4cba-71d3-c825-0872-0bfdb0f802ee"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "master-bedroom", 10, 1, null, null, "", "" },
                    { new Guid("6e43f452-d004-55c5-b117-e739f182b960"), 1400m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "track-lights", "Track Lights", 2, "dining-room", 6, 4, null, null, "", "" },
                    { new Guid("7013e9bc-743f-4fae-1de1-125875eab95f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "base-units", "Base Units", 1, "utility", 0, 1, null, null, "", "" },
                    { new Guid("7177cfc8-c077-947d-d38d-db429090d0ca"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "kids-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("7256070b-395b-d260-b424-38c557ba0565"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "mosquito-mesh", "Mosquito Mesh", 1, "kids-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("740b22e7-37fe-1934-4ed1-88cf46c09cba"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "kitchen", 5, 2, null, null, "", "" },
                    { new Guid("7551f391-d866-923c-8d7f-01f85c42c1c6"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "guest-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("76c70884-adab-a3c4-dbb9-8cb5229a6556"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "guest-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("7afc6fc9-132c-ac4b-9b2c-aab07ea5addc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tall-unit", "Tall Unit", 1, "kitchen", 4, 1, null, null, "pantry", "Pantry" },
                    { new Guid("7b0ef488-6b0e-3c25-9fd8-45a4df9f2894"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "bedroom", 8, 1, null, null, "", "" },
                    { new Guid("7d911351-f769-f2a3-b4d5-70fcfe3734aa"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains / Blinds", 1, "living-room", 3, 1, null, null, "", "" },
                    { new Guid("7e7f8c75-ff94-c870-d88b-264bdbefb931"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "dining-room", 1, 4, null, null, "", "" },
                    { new Guid("7ff96626-cb6c-d2b9-59b2-2e1a78dedc0b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("80e54c61-f0a2-e6a0-05d8-14dfcf525829"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "living-room", 7, 2, null, null, "", "" },
                    { new Guid("81dfbaea-489b-9cda-39aa-491c08f69698"), 65000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "sofa", "Sofa", 2, "drawing-room", 0, 4, null, null, "", "" },
                    { new Guid("8317d36b-d047-58c9-9c8d-c50be956f411"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "kids-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("842455d4-edc6-642e-d6b8-ee8448aa78b3"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "kids-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("84a70b46-1b55-c275-4a2a-c325c5590df2"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "dining-room", 8, 1, null, null, "", "" },
                    { new Guid("84d6272a-3092-5b74-93b1-316b64086f59"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "kitchen", 7, 2, null, null, "", "" },
                    { new Guid("8622bcbe-b62b-9825-cdb6-ab4dadf8330d"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "kitchen", 3, 1, null, null, "", "" },
                    { new Guid("89a0aa9d-9566-86bc-7f0e-820df1ceffd1"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("89b1e1d6-01b6-597a-4711-0786e5655be5"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "utility", 7, 2, null, null, "", "" },
                    { new Guid("89b2e6a3-7c33-4863-42c8-211b49d51d67"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "bedroom", 1, 4, null, null, "", "" },
                    { new Guid("89e1d789-38d2-4861-a567-b9661efaa685"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("8bf70c75-0c40-1431-b3a8-5f7aa85c8e1c"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "living-room", 1, 4, null, null, "", "" },
                    { new Guid("8c5a90af-8328-4767-2a7c-90ab98bc4339"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "master-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("8cde98a8-5bf6-1e2d-afe3-56f69d20cac4"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "bedroom", 6, 1, null, null, "", "" },
                    { new Guid("8d68451a-399d-a33b-1e6e-91fcead2831e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "bedroom", 9, 1, null, null, "", "" },
                    { new Guid("8d6acfb7-c5ad-568a-b454-cadf10622659"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "bedroom", 5, 2, null, null, "", "" },
                    { new Guid("8db2cdd0-6a45-3cc2-f6f4-d7fc2fcf7417"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "countertop", "Countertop", 1, "kitchen", 1, 2, null, null, "", "" },
                    { new Guid("8e912744-2d39-4669-5128-4cc4d6ab4725"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "master-bedroom", 2, 1, null, null, "", "" },
                    { new Guid("8ef4477b-108c-93c9-bed3-d6b95ea8013f"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-counter", "Breakfast Counter", 1, "kitchen", 6, 2, null, null, "", "" },
                    { new Guid("8f0683b9-fe47-7bce-fe90-a86003c0f97b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cob-lights", "COB Lights", 1, "drawing-room", 3, 2, null, null, "", "" },
                    { new Guid("8fe0e6e4-cd54-b34e-8496-8fd61ab11a71"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "kids-bedroom", 2, 2, null, null, "", "" },
                    { new Guid("92f928e6-df2e-fad9-09cd-dd1713cc12d5"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "kids-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("93a69f8e-57cf-2716-8e58-83d5ad72549c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "living-room", 1, 1, null, null, "", "" },
                    { new Guid("948e93ce-b1fa-a11d-65c6-2ff94e5e812d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "kids-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("9606c256-8e0c-4769-9e02-42f11613ead5"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "guest-bedroom", 2, 2, null, null, "", "" },
                    { new Guid("963018bc-8482-4b9b-1c71-d3f045ff1455"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "living-room", 3, 2, null, null, "", "" },
                    { new Guid("96f084c0-009e-394e-7ff8-92565dd2028e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "floating-shelf", "Floating Shelf", 1, "", 0, 2, null, null, "", "" },
                    { new Guid("973674ad-8917-307b-d7eb-de68b1c3b1c9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("976d1a44-2eb4-4a3c-4223-e10653e0d497"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "drawing-room", 2, 2, null, null, "", "" },
                    { new Guid("99efcb62-3315-a9f3-3991-9375d7af31a3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "electrical", "Electrical Work", 3, "", 2, 4, null, null, "", "" },
                    { new Guid("9ce9fdeb-6b1f-1095-cefd-a92a95153619"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "janitor-unit", "Janitor Unit", 1, "utility", 5, 1, null, null, "", "" },
                    { new Guid("9ea52c02-629b-5201-9e44-c89728c68f9b"), 48000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "dining-table", "Dining Table", 2, "dining-room", 0, 4, null, null, "", "" },
                    { new Guid("a183877e-716f-b946-c20d-37a0bf2b4f4a"), 6500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accessories", "Accessories", 2, "kitchen", 0, 4, null, null, "", "" },
                    { new Guid("a2a45073-82b7-e36a-bbd9-8f98624e5559"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("a40dfb14-f3fa-98b5-65e7-8ad4f48a7ec9"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "kids-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("a59c6394-5def-733e-733e-3667e6f17abe"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("a669cd65-975e-4904-900d-02214ed2e2c5"), 6500m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accessories", "Accessories", 2, "utility", 0, 4, null, null, "", "" },
                    { new Guid("a6fb7bf3-e3a1-88a5-30d8-45b3122cd583"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bar-unit", "Bar Unit", 1, "dining-room", 1, 1, null, null, "", "" },
                    { new Guid("a7fc34ed-0d31-7f6b-3c0f-d78b91f6035e"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "guest-bedroom", 5, 2, null, null, "", "" },
                    { new Guid("a8e5c3da-98a0-b5d0-d505-62d8bab6a3b3"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "bedroom", 4, 2, null, null, "", "" },
                    { new Guid("aa8eb7ab-4b7e-763e-bae8-127881791021"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("ac2fb669-4922-bbdd-885b-919a8c62cd9e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "master-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("ac40642d-9d0e-76a8-324a-8593f6b640ed"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "master-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("acf4aef2-e551-2159-ad45-4c053b87c1a6"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "drawing-room", 0, 1, null, null, "", "" },
                    { new Guid("b3cd1a04-464c-a484-7ee2-7e3332be6e7d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "utility", 6, 4, null, null, "", "" },
                    { new Guid("b5a8a7f2-b04b-ea3e-18af-80bd16dfbccd"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "kids-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("b88f599c-9b90-4bd5-56bd-87285f94d215"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "fluted-panel", "Fluted Panel", 1, "kitchen", 1, 1, null, null, "", "" },
                    { new Guid("b9af130b-b9e3-a6f5-20c6-09e4dfa8ba43"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("ba2f2c50-4316-dc18-87e7-ae0ae6d11c3b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 5, 1, null, null, "used-clothes", "Used Clothes" },
                    { new Guid("baf3c598-4a02-658c-92dc-214500406d07"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "bedroom", 0, 1, null, null, "", "" },
                    { new Guid("bb19e104-876d-f532-af36-95fb7bcf7459"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("bbe388be-2ad9-5316-0b0c-8c32b0392274"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "living-room", 0, 1, null, null, "", "" },
                    { new Guid("bd2306ad-b7dc-2719-af2a-49fc171cb0da"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "storage-unit", "Storage Unit", 1, "living-room", 6, 1, null, null, "", "" },
                    { new Guid("bd42864a-f117-9b92-3f60-fd399cf66a34"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("bf8275cd-e391-a72f-8d59-1670386e47af"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("bff0369c-3962-ba78-394f-a8bbcda00fd2"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "kitchen", 6, 2, null, null, "", "" },
                    { new Guid("c08db93d-2cf3-8d3b-2ac7-1304d8fddd52"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 4, 1, null, null, "sliding-glass", "Sliding Glass" },
                    { new Guid("c14f66cb-c3d6-8027-948e-28f66a1e6a52"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "plumbing", "Plumbing Work", 3, "", 3, 4, null, null, "", "" },
                    { new Guid("c21acf4c-f03d-69d5-bf57-d1c4fd8126ae"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "drawing-room", 10, 1, null, null, "", "" },
                    { new Guid("c292e758-2267-c963-8cb6-7917152bac09"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bay-window-paneling", "Bay Window Paneling", 1, "guest-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("c2ecb214-8196-97a6-beb5-607725cdadf9"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "drawing-room", 1, 1, null, null, "", "" },
                    { new Guid("c5e01000-9a70-4044-05b2-bef0b439da18"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "flooring", "Flooring", 1, "", 0, 1, null, null, "", "" },
                    { new Guid("c5fc00ce-ece2-c8f6-4747-8f78c0b88d92"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "drawing-room", 4, 2, null, null, "", "" },
                    { new Guid("c76a0438-4600-5237-f1e2-c66b141df12e"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "guest-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("c7b0e1f3-5e7c-7bed-4fa3-9e8a4fbe4744"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "crockery-unit", "Crockery Unit", 1, "dining-room", 0, 1, null, null, "", "" },
                    { new Guid("c8543641-52ea-2bd3-96b4-c697d6a338c4"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "iron-grills", "Iron Grills", 1, "utility", 8, 1, null, null, "", "" },
                    { new Guid("c93df9f8-8f78-94f6-5792-eec485b76bc7"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "drawing-room", 2, 4, null, null, "", "" },
                    { new Guid("c94ce885-b734-8fa2-9302-b47bd711cdd8"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "kids-bedroom", 0, 1, null, null, "", "" },
                    { new Guid("c9d6c282-34b2-f86b-16dd-bdb4524de2bc"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "kids-bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("c9eede4e-a70e-a372-e59f-00ed5e52823a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "master-bedroom", 2, 2, null, null, "", "" },
                    { new Guid("ca174937-dffd-a8d0-4d80-79e4620ddbad"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("cf283c9f-2850-a1d1-5993-c6e6afada52e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "drawing-room", 0, 1, null, null, "", "" },
                    { new Guid("d184f702-0d39-c3e8-6ecc-c2b4137acfd7"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "dining-room", 2, 4, null, null, "", "" },
                    { new Guid("d344efbc-75ae-e70b-085f-4ba8c11d1e10"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bar-unit", "Bar Unit", 1, "drawing-room", 1, 1, null, null, "", "" },
                    { new Guid("d3e3720f-4677-0a27-bf7e-fcb64448cdc0"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "bookshelf", "Book Shelf Unit", 1, "guest-bedroom", 9, 1, null, null, "", "" },
                    { new Guid("d552ec0b-c683-f55e-3bb5-d8c2b158b8e9"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tall-unit", "Tall Unit", 1, "kitchen", 5, 1, null, null, "appliance", "Appliance" },
                    { new Guid("d5ffea32-e0e6-c37a-e7b2-adabdc10499a"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "magnetic-track-lights", "Magnetic Track Lights", 1, "dining-room", 7, 2, null, null, "", "" },
                    { new Guid("d749db7d-091d-86d8-a9d9-5dda78954b17"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table-wall-storage", "Study Table - Wall Storage", 1, "master-bedroom", 8, 1, null, null, "", "" },
                    { new Guid("da9c4317-ec72-2819-5f4b-af3b65caa955"), 18000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "coffee-table", "Coffee Table", 2, "drawing-room", 1, 4, null, null, "", "" },
                    { new Guid("db38bbf2-8195-7b0f-fc80-db4c86702a08"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "bedroom", 0, 1, null, null, "hinged-7", "Hinged - 7'" },
                    { new Guid("db8973a2-3bd0-eaba-c464-23f693611bb7"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "drawing-room", 5, 2, null, null, "", "" },
                    { new Guid("dc07aec4-0bda-87a6-ba92-261180e2181c"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 3, 1, null, null, "sliding-full", "Sliding - Full Height" },
                    { new Guid("dc2627b4-f9af-4589-1eb8-fa6207dd0275"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "seating-unit", "Seating Unit", 1, "bedroom", 10, 1, null, null, "", "" },
                    { new Guid("dcdc6444-c6a1-b849-22c6-28126387e1c3"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "cove-lights", "Cove Lights", 1, "dining-room", 5, 2, null, null, "", "" },
                    { new Guid("ddc11574-d840-64de-6023-c7d47c6b4daa"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "breakfast-counter-arch", "Breakfast Counter - Arch", 1, "kitchen", 3, 2, null, null, "", "" },
                    { new Guid("e01f66c9-8251-9920-0e73-5b550bc8f957"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "open-shelves", "Shelves", 1, "kitchen", 4, 2, null, null, "", "" },
                    { new Guid("e041ba71-583b-abfb-09ee-db7e1163a98f"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "drawing-room", 2, 4, null, null, "", "" },
                    { new Guid("e0732ae9-2ac7-731c-201a-af8634c66c6c"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "living-room", 5, 1, null, null, "", "" },
                    { new Guid("e07ea364-9cba-2ac2-f621-9780bed6d020"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "guest-bedroom", 1, 4, null, null, "", "" },
                    { new Guid("e0a73010-0ed5-3374-ede3-445731fce633"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "master-bedroom", 1, 1, null, null, "hinged-full", "Hinged - Full Length" },
                    { new Guid("e32482e9-2ebd-889a-0dc9-67611b515cd1"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "kitchen", 3, 1, null, null, "", "" },
                    { new Guid("e3ebb2be-9e35-5cef-9b07-e86c022a0966"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "bedroom", 1, 2, null, null, "", "" },
                    { new Guid("e4bf6dfd-3a25-8ea7-8f59-f67e83d4e587"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "rafters-pu", "Rafters with PU", 1, "drawing-room", 6, 2, null, null, "", "" },
                    { new Guid("ea1484fa-dd7b-8200-0386-7c1557d7b585"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "console-unit", "Console Unit", 1, "dining-room", 9, 1, null, null, "", "" },
                    { new Guid("ea22d1d4-99b3-cd60-5ede-95ee312a9cbb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "living-room", 2, 1, null, null, "", "" },
                    { new Guid("ec0959a6-3f22-974f-c725-45ee6340333e"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "painting", "Painting", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("ec4f75b5-a3b7-216a-03dd-169088351ecb"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "base-units", "Base Units", 1, "kitchen", 0, 1, null, null, "", "" },
                    { new Guid("ec96e3e8-f7c4-138b-8cc3-39ddf800c9e0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-wallpaper", "Accent Wall - Wallpaper", 1, "drawing-room", 3, 1, null, null, "", "" },
                    { new Guid("ed117801-ad5f-c3fd-4252-f7d9700f05fc"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "groove-shutters", "Groove Shutters", 1, "kitchen", 2, 1, null, null, "", "" },
                    { new Guid("ed18318d-2dde-a226-a70d-1e95083c452b"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wardrobe", "Wardrobe", 1, "guest-bedroom", 2, 1, null, null, "sliding-7", "Sliding - 7'" },
                    { new Guid("ed72e572-8454-6471-f082-9ea35c18e444"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "utility", 4, 1, null, null, "", "" },
                    { new Guid("ee874ffa-921d-7c06-4d9b-00c0feaa7284"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "master-bedroom", 1, 2, null, null, "", "" },
                    { new Guid("eef1154b-e8d3-edab-f3b3-717a56b5842d"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wall-panelling", "Wall Panelling", 1, "", 1, 1, null, null, "", "" },
                    { new Guid("f0325c02-e099-589b-a748-601aaf1de3f1"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains / Blinds", 1, "drawing-room", 3, 1, null, null, "", "" },
                    { new Guid("f1a36782-3538-4b3e-5305-8e1aa541cfff"), null, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "curtains", "Curtains / Blinds", 1, "dining-room", 4, 1, null, null, "", "" },
                    { new Guid("f394106a-4e4e-74d5-dc92-4e4a0707a05d"), 850m, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "panel-lights", "Down / Panel Lights", 2, "living-room", 2, 4, null, null, "", "" },
                    { new Guid("f3a6c3a1-6af2-cb34-791f-92d27da0bf56"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "loft", "Loft", 1, "utility", 3, 1, null, null, "", "" },
                    { new Guid("f3e07188-8fda-dabe-7b8b-a58ec2c1eb3b"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "pooja-unit", "Pooja Unit", 1, "dining-room", 10, 1, null, null, "", "" },
                    { new Guid("f5e8b08b-2461-b66b-2dd6-63e5e7645bd3"), 28000m, "furniture", "Furniture", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "settee", "Settee", 2, "dining-room", 3, 4, null, null, "", "" },
                    { new Guid("f795d839-d606-9471-f535-81bc48b34fcb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "tv-unit", "TV Unit", 1, "dining-room", 2, 2, null, null, "", "" },
                    { new Guid("f9ed2173-97ac-63d7-f8c0-9fc909a4992f"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "beading", "Beadings", 1, "master-bedroom", 4, 2, null, null, "", "" },
                    { new Guid("fbfa8ca2-b208-7da7-c830-017be1ad0c69"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "false-ceiling", "False Ceiling + Paint", 1, "utility", 3, 1, null, null, "", "" },
                    { new Guid("fc451b46-1cce-836b-5fcd-34609e4a05c0"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "accent-wall-paneling", "Accent Wall - Paneling", 1, "kids-bedroom", 3, 1, null, null, "", "" },
                    { new Guid("fc5e7e57-abb3-bd3f-9d18-91a00f00b1eb"), null, "carpentry", "Carpentry", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "partition", "Partition", 1, "master-bedroom", 6, 1, null, null, "", "" },
                    { new Guid("fd3e7023-600a-279a-24c4-22d586b6de6b"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "profile-lights", "Profile Lights", 1, "living-room", 4, 2, null, null, "", "" },
                    { new Guid("fd9c9c00-5407-459b-eda9-a83f237019e8"), null, "modular", "Modular", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "study-table", "Study Table", 1, "guest-bedroom", 7, 2, null, null, "", "" },
                    { new Guid("fe364e61-11ff-5b5c-e050-af1dc79932ca"), null, "others", "Others", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, true, "wooden-ceiling", "Wooden Ceiling", 1, "living-room", 1, 1, null, null, "", "" }
                });

            migrationBuilder.InsertData(
                table: "QuotationRates",
                columns: new[] { "Id", "CarcassMaterial", "CreatedAt", "CreatedByEmployeeId", "EffectiveFrom", "Finish", "IsActive", "ItemKey", "RatePerUnit", "ShutterMaterial", "UnitOfMeasure", "UpdatedAt", "UpdatedByEmployeeId", "VariantKey" },
                values: new object[,]
                {
                    { new Guid("039c6aa9-80c5-6841-3cfc-277813a9e27c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "main-door-paneling", 1800m, "", 1, null, null, "" },
                    { new Guid("0c9297fe-a7f4-8185-66de-810a0887ae88"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "mosquito-mesh", 350m, "", 1, null, null, "" },
                    { new Guid("12e62c24-fbfb-dbbc-8813-884661757690"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "storage-unit", 1600m, "", 1, null, null, "" },
                    { new Guid("153d6b68-950c-8450-c56a-30674dc7e687"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3200m, "", 1, null, null, "" },
                    { new Guid("1a77a17f-d906-5578-f11c-730230c4db27"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 1850m, "", 1, null, null, "hinged-7" },
                    { new Guid("1b5186b2-9740-ab06-cef6-0e297ada3683"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "cob-lights", 450m, "", 2, null, null, "" },
                    { new Guid("2069b4dc-8e26-d3e5-b145-7d81b717a9e6"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Acrylic", true, "wall-units", 3600m, "HDHMR", 1, null, null, "wooden" },
                    { new Guid("28a05ef8-da4e-2821-e42f-c0911c5af2e7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "beading", 350m, "", 2, null, null, "" },
                    { new Guid("2cb4e615-90cd-e74d-7691-f83918fbb31a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "loft", 2400m, "", 1, null, null, "" },
                    { new Guid("30b421a4-9c7c-64af-70f7-bbb7d4901c42"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2000m, "", 1, null, null, "hinged-full" },
                    { new Guid("3bf281c2-fda8-3d00-9357-6160301c1d42"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "cove-lights", 500m, "", 2, null, null, "" },
                    { new Guid("3d1d1bf5-cc48-0c66-457f-3cfe7ba517b9"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "accent-wall-paneling", 1300m, "", 1, null, null, "" },
                    { new Guid("3df61d4e-92d0-2908-1f04-4f2ab63f9b22"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "base-units", 3800m, "", 1, null, null, "" },
                    { new Guid("477d2462-f597-33f6-54c0-d0e64cc00f14"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "arch", 1100m, "", 2, null, null, "" },
                    { new Guid("4af4b50c-53f9-0d32-2e89-66e53defeb02"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bookshelf", 1900m, "", 1, null, null, "" },
                    { new Guid("4c560537-8cf3-b173-a8ec-586095507fda"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "rafters-pu", 1250m, "", 2, null, null, "" },
                    { new Guid("4f7a88bc-23ff-bc2b-a0a0-14fc058422ec"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bay-window-paneling", 1350m, "", 1, null, null, "" },
                    { new Guid("50cbfd48-70e4-c297-e525-af90929e2865"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "false-ceiling", 260m, "", 1, null, null, "" },
                    { new Guid("57410f5e-1461-d13e-e003-46b62352da78"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "groove-shutters", 1400m, "", 1, null, null, "" },
                    { new Guid("57a75156-a75e-bd88-d33d-024027456c7e"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Acrylic", true, "base-units", 4200m, "HDHMR", 1, null, null, "" },
                    { new Guid("6057afbf-feb6-8ab8-a818-1ec7e95caf77"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "study-table", 2600m, "", 2, null, null, "" },
                    { new Guid("63858fb0-ae6b-4fbb-16d8-05c54da5a105"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3200m, "", 1, null, null, "wooden" },
                    { new Guid("63aee5bb-3d60-6aa5-9a15-326fcb19f6b5"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shelf", 1800m, "", 1, null, null, "" },
                    { new Guid("63e8ca8d-4725-1f5a-d280-6e788de7a9ca"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "ms-rods", 600m, "", 2, null, null, "" },
                    { new Guid("68551bfa-72fb-1fc0-6c35-808a482a4d9b"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "magnetic-track-lights", 900m, "", 2, null, null, "" },
                    { new Guid("6a4281e2-73c0-6799-9d4c-98f276394c32"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2300m, "", 1, null, null, "sliding-full" },
                    { new Guid("6c8e4e17-aba0-98c9-a548-bb2c5848abbf"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "countertop", 1600m, "", 2, null, null, "" },
                    { new Guid("6e86fff1-efa9-b455-0de6-974491be5ef7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2150m, "", 1, null, null, "sliding-7" },
                    { new Guid("6f9ad67f-03de-62a2-a6be-006fe4d0edb6"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "crockery-unit", 1950m, "", 1, null, null, "" },
                    { new Guid("74031370-9dcf-3a1a-e7f8-b299005e2d1a"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "console-unit", 1500m, "", 1, null, null, "" },
                    { new Guid("766c30b8-be5c-596c-10db-94a0f318ffc7"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "flooring", 180m, "", 1, null, null, "" },
                    { new Guid("7f583bea-6d0a-06e9-dc07-18746126a4e3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "painting", 45m, "", 1, null, null, "" },
                    { new Guid("8a4f5987-ebd3-26f2-fe44-0b787a908443"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "pooja-unit", 2600m, "", 1, null, null, "" },
                    { new Guid("8d378ed8-d938-cdbb-f743-2deab5d25104"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "shoe-rack", 1600m, "", 1, null, null, "" },
                    { new Guid("9045633f-c77d-706e-c49e-0dc241d66c82"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "profile-lights", 550m, "", 2, null, null, "" },
                    { new Guid("92a5cdc8-65cb-de09-4d07-a0c62b8793ca"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-units", 3400m, "", 1, null, null, "glass" },
                    { new Guid("972b45d9-9bc8-851a-0a31-7d288d70aa64"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wooden-ceiling", 850m, "", 1, null, null, "" },
                    { new Guid("9739a6d2-f17d-02d1-2f96-2bab5e28d2cb"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-shelf", 2600m, "", 1, null, null, "" },
                    { new Guid("98f973c8-e209-70c0-46e1-605d98593fff"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "floating-shelf", 1200m, "", 2, null, null, "" },
                    { new Guid("9a8d0ec8-2657-f122-2401-b09d881b8b3e"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 1700m, "", 1, null, null, "used-clothes" },
                    { new Guid("9df2fd07-424d-25b4-e7d1-93cdcd74e0c9"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "study-table-wall-storage", 2200m, "", 1, null, null, "" },
                    { new Guid("9e830e1e-e44c-6094-8dcd-7e33e1c27bfc"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tv-unit", 2400m, "", 2, null, null, "" },
                    { new Guid("a1ee74b0-7711-b449-aa7f-768cea50e2c8"), "BWP", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "Glass", true, "wall-units", 3800m, "Profile", 1, null, null, "glass" },
                    { new Guid("a20ffbd1-c32f-3f10-a34f-63cd706b650c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "fluted-panel", 1200m, "", 1, null, null, "" },
                    { new Guid("a96f91e9-a77f-2392-3fb3-0e7e20dd99cb"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-counter", 2800m, "", 2, null, null, "" },
                    { new Guid("af285b6a-9530-ace2-1bcf-45281a02ecdf"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "breakfast-counter-arch", 1200m, "", 2, null, null, "" },
                    { new Guid("b684da8b-af3f-0930-d65a-b86e97343af8"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tall-unit", 3900m, "", 1, null, null, "appliance" },
                    { new Guid("c4352f6c-3521-5c03-2e24-371181339e3d"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "accent-wall-wallpaper", 900m, "", 1, null, null, "" },
                    { new Guid("c4fc4430-cf12-c71e-b43c-badd25d83a26"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "seating-unit", 2100m, "", 1, null, null, "" },
                    { new Guid("d10c259b-2160-bdd2-de99-a97174ea3ac6"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "partition", 1400m, "", 1, null, null, "" },
                    { new Guid("d966e803-e6b3-6283-db9a-e799ff609e79"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "bar-unit", 2000m, "", 1, null, null, "" },
                    { new Guid("da00908b-0152-62a9-cab5-19686f1d7762"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "tall-unit", 3600m, "", 1, null, null, "pantry" },
                    { new Guid("dd98ac50-3071-a054-8878-60a8822decae"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wall-panelling", 1100m, "", 1, null, null, "" },
                    { new Guid("e15bc135-8a46-5355-a790-1b6db34b36d3"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "wardrobe", 2600m, "", 1, null, null, "sliding-glass" },
                    { new Guid("e4e8451b-b1d7-9c37-0c8f-48a799164eb0"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "jali-partition", 1400m, "", 1, null, null, "" },
                    { new Guid("e7f7fd7c-68cb-1bb8-2540-cfd73ad6edb1"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "janitor-unit", 2200m, "", 1, null, null, "" },
                    { new Guid("ecc8d789-593b-3716-707e-f583b1796a76"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "open-shelves", 900m, "", 2, null, null, "" },
                    { new Guid("ee596b21-b4e8-bafc-3292-23ea68380cbc"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "iron-grills", 900m, "", 1, null, null, "" },
                    { new Guid("fabaa00d-555e-d02c-09c5-05f49a21338c"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "curtains", 450m, "", 1, null, null, "" },
                    { new Guid("fca76c78-a5ac-2612-8350-9b06230f3314"), "", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2026, 1, 1), "", true, "dado-tiles", 220m, "", 1, null, null, "" }
                });
        }
    }
}
