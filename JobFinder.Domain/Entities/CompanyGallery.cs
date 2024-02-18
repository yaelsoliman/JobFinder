using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class CompanyGallery : BaseEntity
{
    [ForeignKey(nameof(Company))]
    public Guid CompanyId { get; set; }

    public string? Image { get; set; }
}
