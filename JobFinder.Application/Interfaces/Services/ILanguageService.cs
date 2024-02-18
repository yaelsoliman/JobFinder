using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface ILanguageService : IBaseService<Language>, IPaginateService<Language, LanguageSearch>
{
}
