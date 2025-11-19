using System.ComponentModel.DataAnnotations;

namespace BookPlatform.API.Geography.Interfaces.REST.Resources;

public record CreateCountryResource(
    [Required] string Name,
    [Required] string Abbreviation,
    [Required] string Capital,
    [Required] string Currency,
    [Required] string Phone,
    [Required] long Population,
    string FlagUrl,
    string EmblemUrl,
    string OrthographicMapUrl
);