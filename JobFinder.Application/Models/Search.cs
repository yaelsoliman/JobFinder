using JobFinder.Shared.Common;

namespace JobFinder.Application.Models;

public interface ISearch
{

}

public class Search : ISearch
{

    public Search() 
    { 
    }

    public string? Keyword { get; set; }
}

public class SkillSearch : Search
{

}

public class ReferenceSearch : Search
{

}

public class ProjectSearch : Search
{

}

public class LanguageSearch : Search
{

}

public class CertificateSearch : Search
{

}

public class CompanySearch : Search
{

}

public class EducationSearch : Search
{

}

public class ExperienceSearch : Search
{

}

public class ApplicantSearch : Search
{

}

public class ApplicantJobSearch : Search
{
    public Guid? ApplicantId { get; set; }
    public Guid? JobId { get; set; }
}

public class JobSearch : Search
{
    public Guid? CompanyId { get; set; }
    public string? JobCode { get; set; }
    public JobShiftPreferred? JobShift { get; set; }
    public JobLevel? JobLevel { get; set; }
    public JobType? JobType { get; set; }
    public List<Guid>? Skills { get; set; }
    public List<Guid>? Languages { get; set; }
}