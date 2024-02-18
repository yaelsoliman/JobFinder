using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFinder.Domain.Entities;
public class Applicant : BaseEntity
{
    public string? Name { get; set; }
    public string? Image { get; set; }
    public Gender Gender { get; set; }
    public DateTime DOB { get; set; }
    public int YearsOfExperience { get; set; }
    public JobLevel JobLevel { get; set; }
    public MilitaryStatus MilitaryStatus { get; set; }
    public JobShiftPreferred JobShiftPreferred { get; set; } = JobShiftPreferred.Both;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }

    public Guid ApplicationUserId { get; set; }

    public virtual ICollection<ApplicantSkill>? ApplicantSkills { get; set; }
    public virtual ICollection<ApplicantLanguage>? ApplicantLanguages { get; set; }
    public virtual ICollection<Education>? Educations { get; set; }
    public virtual ICollection<Certificate>? Certificates { get; set; }
    public virtual ICollection<Experience>? Experiences { get; set; }
    public virtual ICollection<Project>? Projects { get; set; }
    public virtual ICollection<Reference>? References { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    [NotMapped]
    public int Day { get; set; }

    [NotMapped]
    public int Month { get; set; }

    [NotMapped]
    public int Year { get; set; }

    [NotMapped]
    public List<string>? NewSkills { get; set; }

    [NotMapped]
    public List<Guid>? SelectedSkills { get; set; }

    [NotMapped]
    public List<Guid>? SelectedLanguages { get; set; }
}
