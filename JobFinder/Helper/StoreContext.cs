using JobFinder.Application.Models.ServiceModel;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Identity.Models;
using JobFinder.Infrastructure.Store;
using JobFinder.Shared.Common;

namespace JobFinder.Helper;

public class StoreContext : IStoreContext
{
    public UserDto? CurrentUser { get; set; }
    public RoleType? RoleType { get; set; }
    public Company? Company { get; set; }
    public Applicant? Applicant { get; set; }
}
