using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class ApplicantLanguage : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    [ForeignKey(nameof(Language))]
    public Guid LanguageId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Language? Language { get; set; }
}
