using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaApi.Controllers;

[Route("api/VillaApi")]
[ApiController] //IT WILL VALIDATE MODEL STATES AND GIVE BAD REQUESTS IF FAILED
public class VillaApiController : ControllerBase

{
    public ILogger<VillaApiController> _logger;

    private readonly ApplicationDbContext _db;

    public VillaApiController(ILogger<VillaApiController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VillaDTO>> GetVilla()
    {
        return Ok(_db.Villas.ToList());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDTO> GetVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
        if (villa == null)
        {
            return NotFound();
        }

        return Ok(villa);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillaDTO> CreateVilla(VillaCreateDTO villaCreateDto)
    {
        var isValid=TryValidateModel(villaCreateDto);
        
        if (!isValid)
        {
            return BadRequest(ModelState);
        }
       
        var villa = new Villa
        {
            Id = 0,
            Name = villaCreateDto.Name,
            Details = villaCreateDto.Details,
            rate = villaCreateDto.rate,
            sqft = villaCreateDto.sqft,
            occupancy = villaCreateDto.occupancy,
            imageurl = villaCreateDto.imageurl,
            amenity = villaCreateDto.amenity,
            CreatedDate = villaCreateDto.CreatedDate,
            UpdateDate = villaCreateDto.UpdateDate
        };

      

        _db.Villas.Add(villa);

        _db.SaveChanges();

        return StatusCode(StatusCodes.Status201Created, villa);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
        if (villa == null)
        {
            return NotFound();
        }

        _db.Villas.Remove(villa);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateVilla([FromBody] Villa updatedVilla)
    {
        if (updatedVilla.Id == 0)
        {
            return BadRequest();
        }

        var villa = _db.Villas.FirstOrDefault(v => v.Id == updatedVilla.Id);

        if (villa == null)
        {
            return NotFound();
        }

        _db.Villas.Update(updatedVilla);
        _db.SaveChanges();

        return NoContent();
    }

    [HttpPatch(Name = "UpdateVillaPartial")]
    public IActionResult UpdateVillaPartial(int id, [FromBody]JsonPatchDocument<Villa> patchDoc)
    {
        var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
        
        if (villa == null)
        {
            return NotFound();
        }
        
        patchDoc.ApplyTo(villa, ModelState);
        
        var isValid=TryValidateModel(villa);
        
        if (!isValid)
        {
            return BadRequest(ModelState);
        }

        _db.Update(villa);
        _db.SaveChanges();

        return Ok(villa);







    }
}