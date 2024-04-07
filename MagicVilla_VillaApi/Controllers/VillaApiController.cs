using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaApi.Controllers;

[Route("api/VillaApi")]
[ApiController] //IT WILL VALIDATE MODEL STATES AND GIVE BAD REQUESTS IF FAILED
public class VillaApiController: ControllerBase

{
    public ILogger<VillaApiController> _logger;
    public VillaApiController(ILogger<VillaApiController> logger)
    {
        var _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<VillaDTO>> GetVilla()
    {
        return Ok(VillaDataStore.villalist);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDTO> GetVilla(int id)
    {
        if (id == 0)
        {
            _logger.LogError("error getting info with id 0");
            
            
            return BadRequest();
        }
        var villa=VillaDataStore.villalist.FirstOrDefault(v => v.Id == id);
        if (villa==null)
        {
            return NotFound();
        }
        return Ok(villa);
        
        
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDtO)
    {
        

        if (villaDtO.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
            
        }
        villaDtO.Id=VillaDataStore.villalist.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
        
        VillaDataStore.villalist.Add(villaDtO);
        
        
        return CreatedAtAction(nameof(GetVilla),new {id=villaDtO.Id},villaDtO);
        

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
        
        var villa = VillaDataStore.villalist.FirstOrDefault(v => v.Id == id);
        if (villa == null)
        {
            return NotFound();
        }
        VillaDataStore.villalist.Remove(villa);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public IActionResult UpdateVilla([FromBody]VillaDTO villaDtO)
    {
        if (villaDtO.Id== 0)
        {
            return BadRequest();

        }
        var villa=VillaDataStore.villalist.FirstOrDefault(v => v.Id == villaDtO.Id);

        if (villa == null)
        {
            return NotFound();
        }
        
      
        
        VillaDataStore.villalist.Remove(villa);
        VillaDataStore.villalist.Add(villaDtO);
        
       
        return NoContent();
        
        
    }
    
    [HttpPatch("{id:int}",Name="UpdateVillaPartial")]
    
    public IActionResult UpdateVillaPartial(int id,JsonPatchDocument<VillaDTO> patchDoc)
    {
        if (id == 0)
        {
            return BadRequest();
            
        }

        var villa = VillaDataStore.villalist.FirstOrDefault(v => v.Id == id);

        if (villa == null)
        {
            return BadRequest();
        }
        patchDoc.ApplyTo(villa);

        return NoContent();




    }
    
    
   
    
    
    
    
 
   
   
    
    
   
    
  
    
    
}