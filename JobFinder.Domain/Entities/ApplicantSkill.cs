using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class ApplicantSkill : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    [ForeignKey(nameof(Skill))]
    public Guid SkillId { get; set; }

    public virtual Applicant? Applicant { get; set; }
    public virtual Skill? Skill { get; set; }
}
