using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface IReferenceService : IBaseService<Reference>, IPaginateService<Reference, ReferenceSearch>
{
}
