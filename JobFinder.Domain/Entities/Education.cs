using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class Education : BaseEntity
{
    [ForeignKey(nameof(Applicant))]
    public Guid ApplicantId { get; set; }

    public string? Title { get; set; }
    public string? Provider { get; set; }
    public EducationLevel EducationLevel { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    
    public virtual Applicant? Applicant { get; set; }
}
