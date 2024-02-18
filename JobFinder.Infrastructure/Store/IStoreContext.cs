using JobFinder.Application.Models.ServiceModel;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Identity.Models;
using JobFinder.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Infrastructure.Store;
public interface IStoreContext
{
    public UserDto? CurrentUser { get; set; }
    public Company? Company { get; set; }
    public Applicant? Applicant { get; set; }
    public RoleType? RoleType { get; set; }
}
