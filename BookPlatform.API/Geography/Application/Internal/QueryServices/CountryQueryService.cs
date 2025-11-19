using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Geography.Domain.Model.Queries;
using BookPlatform.API.Geography.Domain.Repositories;
using BookPlatform.API.Geography.Domain.Services;

namespace BookPlatform.API.Geography.Application.Internal.QueryServices;

public class CountryQueryService(ICountryRepository countryRepository) : ICountryQueryService
{
    public async Task<IEnumerable<Country>> Handle(GetAllCountriesQuery query)
    {
        return await countryRepository.ListAsync();
    }

    public async Task<Country?> Handle(GetCountryByIdQuery query)
    {
        return await countryRepository.FindByIdAsync(query.Id);
    }
}