namespace GovHack22API.Controllers;

using GovHack22API.Domain;
using GovHack22API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyContext _dbContext;

    public PropertyController(PropertyContext dbContext)
    {
        _dbContext = dbContext;
    
    }

    [HttpGet("featured")]
    public List<Property> Get()
    {
       return  _dbContext.Properties
            .Include(x => x.Images)
            .Include(x => x.FloorPlan)
            .Include(x => x.Facilities)
            .Include(x => x.Owner)
            .Include(x => x.Location)
            .Include(x => x.Spaces)
                .ThenInclude(x => x.Availability)
            .ToList();
    }

    [HttpPost("book")]
    public string Post([FromBody] Property property)
    {
        _dbContext.Properties.Add(property);
        _dbContext.SaveChanges();

       return "Created";
    }
}
