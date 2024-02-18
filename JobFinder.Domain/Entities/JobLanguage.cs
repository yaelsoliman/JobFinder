using JobFinder.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobLanguage : BaseEntity
{
    [ForeignKey(nameof(Job))]
    public Guid JobId { get; set; }

    [ForeignKey(nameof(Language))]
    public Guid LanguageId { get; set; }

    public virtual Job? Job { get; set; }
    public virtual Language? Language { get; set; }
}
