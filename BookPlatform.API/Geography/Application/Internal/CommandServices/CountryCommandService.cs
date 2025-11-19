using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Geography.Domain.Model.Commands;
using BookPlatform.API.Geography.Domain.Repositories;
using BookPlatform.API.Geography.Domain.Services;
using BookPlatform.API.Shared.Domain.Repositories;

namespace BookPlatform.API.Geography.Application.Internal.CommandServices;

public class CountryCommandService(ICountryRepository countryRepository, IUnitOfWork unitOfWork) 
    : ICountryCommandService
{
    public async Task<Country?> Handle(CreateCountryCommand command)
    {
        var existingCountry = await countryRepository.FindByNameAsync(command.Name);
        if (existingCountry != null)
        {
            throw new Exception("Country with this name already exists.");
        }

        var country = new Country(command);
        try
        {
            await countryRepository.AddAsync(country);
            await unitOfWork.CompleteAsync();
            return country;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error creating country: {e.Message}");
            return null;
        }
    }
}