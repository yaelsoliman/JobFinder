using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class Certificate : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    public string? Title { get; set; }
    public string? Provider { get; set; }
    public DateTime CertifiedAt { get; set; }
    public string? Image { get; set; }

    public virtual Applicant? Applicant { get; set; }
}
