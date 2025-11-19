using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Geography.Domain.Model.Queries;

namespace BookPlatform.API.Geography.Domain.Services;

public interface ICountryQueryService
{
    Task<IEnumerable<Country>> Handle(GetAllCountriesQuery query);
    Task<Country?> Handle(GetCountryByIdQuery query);
}