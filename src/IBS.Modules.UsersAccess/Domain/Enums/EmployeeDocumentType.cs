namespace IBS.Modules.UsersAccess.Domain.Enums;

/// <summary>Category of an uploaded employee document (spec section 4.3).</summary>
public enum EmployeeDocumentType
{
    Other = 0,
    OfferLetter = 1,
    AppointmentLetter = 2,
    IdProof = 3,
    AddressProof = 4,
    EducationCertificate = 5,
    ExperienceCertificate = 6,
    Resume = 7,
    Contract = 8,
    Photo = 9
}
