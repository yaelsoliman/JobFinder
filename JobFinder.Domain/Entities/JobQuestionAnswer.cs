using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobQuestionAnswer : BaseEntity
{
    [ForeignKey(nameof(Question))]
    public Guid JobQuestionId { get; set; }

    public string? Answer { get; set; }
    public bool IsCorrect { get; set; }

    public virtual JobQuestion? Question { get; set; }
}
