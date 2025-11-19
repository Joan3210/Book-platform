using System.Net.Mime;
using BookPlatform.API.Geography.Domain.Model.Queries;
using BookPlatform.API.Geography.Domain.Services;
using BookPlatform.API.Geography.Interfaces.REST.Resources;
using BookPlatform.API.Geography.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookPlatform.API.Geography.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Countries")]
public class CountriesController(
    ICountryCommandService countryCommandService,
    ICountryQueryService countryQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a country",
        Description = "Creates a new country in the database.",
        OperationId = "CreateCountry")]
    [SwaggerResponse(201, "Country created successfully", typeof(CountryResource))]
    [SwaggerResponse(400, "Bad request")]
    public async Task<IActionResult> CreateCountry([FromBody] CreateCountryResource resource)
    {
        var command = CreateCountryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var country = await countryCommandService.Handle(command);
        
        if (country is null) return BadRequest("Could not create country. It might already exist.");
        
        var countryResource = CountryResourceFromEntityAssembler.ToResourceFromEntity(country);
        return CreatedAtAction(nameof(GetCountryById), new { id = countryResource.Id }, countryResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all countries",
        Description = "Retrieves the list of all countries.",
        OperationId = "GetAllCountries")]
    [SwaggerResponse(200, "Countries retrieved successfully", typeof(IEnumerable<CountryResource>))]
    public async Task<IActionResult> GetAllCountries()
    {
        var query = new GetAllCountriesQuery();
        var countries = await countryQueryService.Handle(query);
        var resources = countries.Select(CountryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get country by ID",
        Description = "Retrieves a country by its unique identifier.",
        OperationId = "GetCountryById")]
    [SwaggerResponse(200, "Country retrieved successfully", typeof(CountryResource))]
    [SwaggerResponse(404, "Country not found")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        var query = new GetCountryByIdQuery(id);
        var country = await countryQueryService.Handle(query);
        if (country == null) return NotFound();
        var resource = CountryResourceFromEntityAssembler.ToResourceFromEntity(country);
        return Ok(resource);
    }
}