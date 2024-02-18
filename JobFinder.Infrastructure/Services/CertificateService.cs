using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Infrastructure.Services;

public class CertificateService : BaseService<Certificate, CertificateSearch>, ICertificateService
{
    public CertificateService(IRepository<Certificate> repo)
        : base(repo)
    {
    }
}
