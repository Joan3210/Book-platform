using BookPlatform.API.Geography.Domain.Model.Aggregates;
using BookPlatform.API.Geography.Interfaces.REST.Resources;

namespace BookPlatform.API.Geography.Interfaces.REST.Transform;

public static class CountryResourceFromEntityAssembler
{
    public static CountryResource ToResourceFromEntity(Country entity)
    {
        return new CountryResource(
            entity.Id,
            entity.Name,
            entity.Abbreviation,
            entity.Capital,
            entity.Currency,
            entity.Phone,
            entity.Population,
            entity.FlagUrl,
            entity.EmblemUrl,
            entity.OrthographicMapUrl
        );
    }
}