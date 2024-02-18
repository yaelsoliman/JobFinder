using JobFinder.Application.Models;
using JobFinder.Application.Models.ServiceModel;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface IJobService : IBaseService<Job>, IPaginateService<Job, JobSearch>
{
    Task<PaginationResponse<Job>> GetJobsForApplicant(PaginationFilter<JobSearch> filter);
    Task<Guid> ApplyForJob(Guid jobId, Guid applicantId);
    Task<Guid> SubmitTest(Guid jobId, List<ApplyJobRequest> applyJobRequest);
    Task<Guid> ApproveApplicant(Guid jobApplicantId);
    Task<Guid> RejectApplicant(Guid jobApplicantId, string note);
    Task<Guid> BanJob(Guid jobId);
    Task<PaginationResponse<JobApplicant>> GetCompanyApplicant(PaginationFilter<ApplicantSearch> filter);
    Task<PaginationResponse<JobApplicant>> GetAppliedJob(PaginationFilter<ApplicantSearch> filter);
    Task<PaginationResponse<JobApplicant>> GetApplicantForJob(PaginationFilter<ApplicantJobSearch> filter);
}
