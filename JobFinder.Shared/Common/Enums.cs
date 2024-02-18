using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JobFinder.Shared.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Male,
    Femail
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum JobLevel
{
    Junior,
    Mid,
    Senior
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MilitaryStatus
{
    Postponed,
    Conscript,
    Discharge,
    Exempt
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EducationLevel
{
    School,
    University,
    Diploma,
    Doctorate
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum JobShiftPreferred
{
    FullTime,
    PartTime,
    Both
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum JobType
{
    InSite,
    Remote,
    Both
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AttachmentType
{
    Image,
    PDF
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QuestionType
{
    Single,
    Multiple
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApplicantRequestStatus
{
    Pending,
    InReview,
    PendingApprove,
    Approved,
    Rejected
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleType
{
    Company,
    Applicant,
    Admin
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PageType
{
    Add,
    Edit,
    Details
}
