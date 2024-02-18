using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class Experience : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    public string? JobPosition { get; set; }

    [ForeignKey(nameof(Company))]
    public Guid? CompanyId { get; set; }

    public string? CompanyName { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Company? Company { get; set; }
}
