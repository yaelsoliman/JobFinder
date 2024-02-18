using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobQuestion : BaseEntity
{
    [ForeignKey(nameof(Job))]
    public Guid JobId { get; set; }

    public string? Question { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Image { get; set; }

    public virtual Job? Job { get; set; }
    public virtual ICollection<JobQuestionAnswer>? JobQuestionAnswers { get; set; }
}
