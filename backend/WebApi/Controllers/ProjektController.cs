using Microsoft.AspNetCore.Mvc;
using Data.Factories;
using Data.Models;
using Data.Services;

[Route("api/[controller]")]
[ApiController]
public class ProjektController : ControllerBase
{
    private readonly IProjektService _projektService;
    private readonly ProjektFactory _projektFactory;

    public ProjektController(IProjektService projektService, ProjektFactory projektFactory)
    {
        _projektService = projektService;
        _projektFactory = projektFactory;
    }

    [HttpGet]
    public IEnumerable<Projekt> Get() => _projektService.GetAll();

    [HttpGet("{projektnummer}")]
    public ActionResult<Projekt> GetProjekt(int projektnummer)
    {
        var projekt = _projektService.GetById(projektnummer);
        if (projekt == null)
        {
            return NotFound();
        }
        return Ok(projekt);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Projekt projekt)
    {
        var nyttProjekt = _projektFactory.CreateProjekt(
            projekt.Namn,
            projekt.Startdatum,
            projekt.Slutdatum,
            projekt.Projektansvarig,
            projekt.Kundnummer,
            projekt.TjanstId,
            projekt.Totalpris,
            projekt.Status
        );

        _projektService.Add(nyttProjekt);

        return CreatedAtAction(nameof(Get), new { id = nyttProjekt.Projektnummer }, nyttProjekt);
    }

    [HttpPut("{projektnummer}")]
    public IActionResult Put(int projektnummer, [FromBody] Projekt projekt)
    {
        var existerandeProjekt= _projektService.GetById(projektnummer);
        if (existerandeProjekt == null)
        {
            return NotFound();
        }

        existerandeProjekt.Namn = projekt.Namn;
        existerandeProjekt.Startdatum = projekt.Startdatum;
        existerandeProjekt.Slutdatum = projekt.Slutdatum;
        existerandeProjekt.Projektansvarig = projekt.Projektansvarig;
        existerandeProjekt.Kundnummer = projekt.Kundnummer;  
        existerandeProjekt.TjanstId = projekt.TjanstId;      
        existerandeProjekt.Totalpris = projekt.Totalpris;
        existerandeProjekt.Status = projekt.Status;

        _projektService.Update(existerandeProjekt);
        return Ok(existerandeProjekt);
    }

}
