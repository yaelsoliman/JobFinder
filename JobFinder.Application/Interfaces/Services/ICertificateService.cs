using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface ICertificateService : IBaseService<Certificate>, IPaginateService<Certificate, CertificateSearch>
{
}
