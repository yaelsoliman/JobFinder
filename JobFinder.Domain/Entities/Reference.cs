using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class Reference : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? Image { get; set; }
    public DateTime? ReferencedAt { get; set; }
    
    public virtual Applicant? Applicant { get; set; }
}
