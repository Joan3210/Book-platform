using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Geography.Domain.Model.Commands;

namespace BookPlatform.API.Geography.Domain.Services;

public interface ICountryCommandService
{
    Task<Country?> Handle(CreateCountryCommand command);
}