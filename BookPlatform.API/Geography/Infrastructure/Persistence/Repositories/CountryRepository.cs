using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Geography.Domain.Repositories;
using BookPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using BookPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookPlatform.API.Geography.Infrastructure.Persistence.Repositories;

public class CountryRepository(AppDbContext context) : BaseRepository<Country>(context), ICountryRepository
{
    public async Task<Country?> FindByNameAsync(string name)
    {
        return await Context.Set<Country>().FirstOrDefaultAsync(c => c.Name == name);
    }
}