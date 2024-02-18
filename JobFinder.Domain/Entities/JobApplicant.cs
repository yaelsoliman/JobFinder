using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobApplicant : BaseEntity
{
    [ForeignKey(nameof(Job))]
    public Guid JobId { get; set; }

    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    public Guid CompanyId { get; set; }

    public bool FinishedTest { get; set; }
    public ApplicantRequestStatus CurrentStatus { get; set; } = ApplicantRequestStatus.Pending;

    public virtual Job? Job { get; set; }
    public virtual Applicant? Applicant { get; set; }
    public virtual ICollection<JobApplicantLifecycle>? JobApplicantLifecycles { get; set; }
}
