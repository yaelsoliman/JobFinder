using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class JobAttachment : BaseEntity
{
    [ForeignKey(nameof(Job))]
    public Guid JobId { get; set; }
    public AttachmentType AttachmentType { get; set; }
    public string? AttachmentPath { get; set; }

    public virtual Job? Job { get; set; }
}
