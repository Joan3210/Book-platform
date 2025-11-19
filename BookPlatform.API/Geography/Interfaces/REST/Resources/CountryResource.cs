namespace BookPlatform.API.Geography.Interfaces.REST.Resources;

public record CountryResource(
    int Id,
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