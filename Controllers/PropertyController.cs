namespace GovHack22API.Controllers;

using GovHack22API.Domain;
using GovHack22API.Models;
using GovHack22API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyContext _dbContext;
    private  Mapper _mapper; 

    public PropertyController(PropertyContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new Mapper();
    }

    [HttpGet("featured")]
    public IList<PropertyResponse> Get()
    {
        var properties = _dbContext.Properties
            .Include(x => x.Images)
            .Include(x => x.FloorPlan)
            .Include(x => x.Facilities)
            .Include(x => x.Owner)
            .Include(x => x.Location)
            .Include(x => x.Spaces)
                .ThenInclude(x => x.Availability)
            .ToList();
            
        var response = new List<PropertyResponse>();

        properties.ForEach(p => response.Add(
            _mapper.MapPropertyResponse(p)
        ));

        return response;
    }

    [HttpPost("book")]
    public string Post([FromBody] Property property)
    {
        _dbContext.Properties.Add(property);
        _dbContext.SaveChanges();

       return "Created";
    }

    [HttpGet("test")]
    public Property Test()
    {
       var x =  _dbContext.Properties
            .Include(x => x.Images)
            .Include(x => x.FloorPlan)
            .Include(x => x.Facilities)
            .Include(x => x.Owner)
            .Include(x => x.Location)
            .Include(x => x.Spaces)
                .ThenInclude(x => x.Availability)
            .FirstOrDefault();
        
        return x;
    }
}
