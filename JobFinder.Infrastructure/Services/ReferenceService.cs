using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class ReferenceService : BaseService<Reference, ReferenceSearch>, IReferenceService
{
    public ReferenceService(IRepository<Reference> repo)
        : base(repo)
    {
    }
}
