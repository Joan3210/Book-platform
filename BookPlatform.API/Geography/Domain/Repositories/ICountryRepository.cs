using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Shared.Domain.Repositories;

namespace BookPlatform.API.Geography.Domain.Repositories;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<Country?> FindByNameAsync(string name);
}