using JobFinder.Domain.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;

public class Company : BaseEntity
{
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Website { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? LinkedIn { get; set; }
    public string? Address { get; set; }
    public string? About { get; set; }

    public Guid ApplicationUserId { get; set; }

    public virtual ICollection<CompanyGallery>? Galleries { get; set; }

    [NotMapped]
    public IFormFile? LogoFile { get; set; }

    [NotMapped]
    public List<IFormFile>? GalleryFiles { get; set; }

    [NotMapped]
    public List<string>? UploadedFiles { get; set; }
}
