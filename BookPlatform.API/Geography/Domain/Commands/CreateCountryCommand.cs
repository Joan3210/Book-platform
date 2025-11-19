namespace BookPlatform.API.Geography.Domain.Model.Commands;

public record CreateCountryCommand(
    string Name,
    string Abbreviation,
    string Capital,
    string Currency,
    string Phone,
    long Population,
    string FlagUrl,
    string EmblemUrl,
    string OrthographicMapUrl
);