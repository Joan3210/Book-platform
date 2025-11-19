using BookPlatform.API.Geography.Domain.Model.Commands;
using BookPlatform.API.Geography.Interfaces.REST.Resources;

namespace BookPlatform.API.Geography.Interfaces.REST.Transform;

public static class CreateCountryCommandFromResourceAssembler
{
    public static CreateCountryCommand ToCommandFromResource(CreateCountryResource resource)
    {
        return new CreateCountryCommand(
            resource.Name,
            resource.Abbreviation,
            resource.Capital,
            resource.Currency,
            resource.Phone,
            resource.Population,
            resource.FlagUrl,
            resource.EmblemUrl,
            resource.OrthographicMapUrl
        );
    }
}