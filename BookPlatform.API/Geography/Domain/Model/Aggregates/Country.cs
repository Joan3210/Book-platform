using BookPlatform.API.Geography.Domain.Model.Commands;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace BookPlatform.API.Geography.Domain.Model.Aggregates;

public class Country : IEntityWithCreatedUpdatedDate
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }
    public string Capital { get; private set; }
    public string Currency { get; private set; }
    public string Phone { get; private set; }
    public long Population { get; private set; }
    public string FlagUrl { get; private set; }
    public string EmblemUrl { get; private set; }
    public string OrthographicMapUrl { get; private set; }
    
    // Audit properties from IEntityWithCreatedUpdatedDate
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }

    protected Country() 
    {
        Name = string.Empty;
        Abbreviation = string.Empty;
        Capital = string.Empty;
        Currency = string.Empty;
        Phone = string.Empty;
        FlagUrl = string.Empty;
        EmblemUrl = string.Empty;
        OrthographicMapUrl = string.Empty;
    }

    public Country(CreateCountryCommand command)
    {
        Name = command.Name;
        Abbreviation = command.Abbreviation;
        Capital = command.Capital;
        Currency = command.Currency;
        Phone = command.Phone;
        Population = command.Population;
        FlagUrl = command.FlagUrl;
        EmblemUrl = command.EmblemUrl;
        OrthographicMapUrl = command.OrthographicMapUrl;
    }
}