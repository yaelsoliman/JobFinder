using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobSkill : BaseEntity
{
    [ForeignKey(nameof(Job))]
    public Guid JobId { get; set; }

    [ForeignKey(nameof(Skill))]
    public Guid SkillId { get; set; }

    public virtual Job? Job { get; set; }
    public virtual Skill? Skill { get; set; }
}
