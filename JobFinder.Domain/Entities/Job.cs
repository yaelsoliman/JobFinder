using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class Job : BaseEntity
{
    [ForeignKey(nameof(Company))]
    public Guid CompanyId { get; set; }
    public string? Title { get; set; }
    public int VacancyCount { get; set; } = 1;
    public string? MiniContent { get; set; }
    public string? Description { get; set; }
    public string? JobCode { get; set; }
    public int? PreferredAge { get; set; }
    public JobShiftPreferred JobShift { get; set; }
    public JobLevel? JobLevel { get; set; }
    public JobType JobType { get; set; }
    public int? WorkHours { get; set; }
    public DateTime? FromTime { get; set; }
    public DateTime? TillTime { get; set; }
    public double? Salary { get;set; }
    public Gender? PreferredGender { get; set; }
    public int? PreferredYearsOfExperience { get; set; }
    public bool HasOnlineTest { get; set; }
    public float? ApprovedAverage { get; set; }
    public bool HasTestInSite { get; set; }

    public bool IsBanned { get; set; }

    public virtual Company? Company { get; set; }
    public virtual ICollection<JobAttachment>? JobAttachments { get; set; }
    public virtual ICollection<JobSkill>? Skills { get; set; }
    public virtual ICollection<JobLanguage>? Languages { get; set; }
    public virtual ICollection<JobQuestion>? Questions { get; set; }

    [NotMapped]
    public bool IsMatchApplicantProfile { get; set; }

    [NotMapped]
    public List<string>? NewSkills { get; set; }

    [NotMapped]
    public List<Guid>? SelectedSkills { get; set; }

    [NotMapped]
    public List<Guid>? SelectedLanguages { get; set; }

    [NotMapped]
    public List<IFormFile>? Attachments { get; set; }

    [NotMapped]
    public bool IsCurrentUserApplied { get; set; }
}
