using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobApplicantAnswer : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    [ForeignKey(nameof(JobQuestionAnswer))]
    public Guid JobQuestionAnswerId { get; set; }

    public bool IsCorrect { get; set; }
    public Guid JobId { get; set; }
    public Guid JobQuestionId { get; set; }
    public Guid JobApplicantId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual JobQuestionAnswer? JobQuestionAnswer { get; set; }

}
