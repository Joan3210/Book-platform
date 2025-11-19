using BookPlatform.API.Shared.Domain.Repositories;
using BookPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace BookPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}