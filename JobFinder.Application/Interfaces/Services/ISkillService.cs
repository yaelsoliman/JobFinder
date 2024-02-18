using JobFinder.Application.Models;
using JobFinder.Domain.Entities;

namespace JobFinder.Application.Interfaces.Services;

public interface ISkillService : IBaseService<Skill>, IPaginateService<Skill, SkillSearch>
{
}
