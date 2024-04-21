using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVilla()
    {
        return Ok(await _db.Villas.ToListAsync());
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VillaDTO>> GetVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var villa =await  _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
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
    public async Task<ActionResult<VillaDTO>> CreateVilla(VillaCreateDTO villaCreateDto)
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
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now
          
        };

      

       _db.Villas.Add(villa);

        await _db.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, villa);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVilla(int id)
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
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVilla([FromBody] VillaUpdateDTO villaUpdateDto)
    {
        if (villaUpdateDto.Id == 0)
        {
            return BadRequest();
        }
        
        var isValid=TryValidateModel(villaUpdateDto);
        
        if (!isValid)
        {
            return BadRequest(ModelState);
        }

        var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == villaUpdateDto.Id);

        if (villa == null)
        {
            return NotFound();
        }
        var updatedVilla=new Villa
        {
            Id = villaUpdateDto.Id,
            Name = villaUpdateDto.Name,
            Details = villaUpdateDto.Details,
            rate = villaUpdateDto.rate,
            sqft = villaUpdateDto.sqft,
            occupancy = villaUpdateDto.occupancy,
            imageurl = villaUpdateDto.imageurl,
            amenity = villaUpdateDto.amenity,
            CreatedDate = villa.CreatedDate,
            UpdateDate = DateTime.Now
        };

        _db.Villas.Update(updatedVilla);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch(Name = "UpdateVillaPartial")]
    public async Task<IActionResult> UpdateVillaPartial(int id, [FromBody]JsonPatchDocument<Villa> patchDoc)
    {
        var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
        
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
        await _db.SaveChangesAsync();

        return Ok(villa);







    }
}