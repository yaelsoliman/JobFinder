using JobFinder.Application.Common.Extensions;
using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Application.Models;
using JobFinder.Domain.Common;
using JobFinder.Domain.Entities;
using JobFinder.Infrastructure.Store;

namespace JobFinder.Infrastructure.Services;

public class CompanyService : BaseService<Company, CompanySearch>, ICompanyService
{

    private readonly IStoreContext _storeContext;

    public CompanyService(IRepository<Company> repo, IStoreContext storeContext)
        : base(repo)
    {
        _storeContext = storeContext;
    }

    public override async Task<PaginationResponse<Company>> PaginateAsync(PaginationFilter<CompanySearch> filter)
    {
        filter ??= new();
        Filters<Company> filters = new();
        filters.Add(filter.Keyword.HasValue(), x => x.Name.ToLower().Contains(filter.Keyword.ToLower()) || 
                                                    x.Mobile.ToLower().Contains(filter.Keyword.ToLower()) ||
                                                    x.Phone.ToLower().Contains(filter.Keyword.ToLower()));
        PaginationResponse<Company> result = await _repo.PaginateAsync(filter, filters);
        return result;
    }

    public async Task<Guid> CustomUpdateAsync(Company model)
    {
        var oldModel = await GetAsync(model.Id, includes: x => x.Galleries);
        oldModel.Phone = model.Phone;
        oldModel.Mobile = model.Mobile;
        oldModel.Website = model.Website;
        oldModel.Facebook = model.Facebook;
        oldModel.Twitter = model.Twitter;
        oldModel.LinkedIn = model.LinkedIn;
        oldModel.About = model.About;
        oldModel.Address = model.Address;
        oldModel.Logo = model.Logo ?? oldModel.Logo;
        if (model.Galleries?.Count > 0)
        {
            oldModel.Galleries = model.Galleries ?? oldModel.Galleries;
        }
        var result = await _repo.UpdateAsync(oldModel);
        return result;
    }
}
