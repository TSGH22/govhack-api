namespace GovHack22API.Controllers;

using GovHack22API.Domain;
using GovHack22API.Models;
using GovHack22API.Models.Request;
using GovHack22API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyContext _dbContext;
    private  Mapper _mapper; 
    private Random _random;
    //private LocationSearchHelper _locationSearchHelper;

    public PropertyController(PropertyContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new Mapper();
        _random = new Random();
       // _locationSearchHelper = new LocationSearchHelper();
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

    [HttpPost("search")]
    public IList<PropertyResponse> Search([FromBody] SearchRequest search)  
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

        if (search.MaxPrice != 0){
            response = response.Where(r => r.Price > search.MaxPrice)
                .ToList();
        }

        if(search.Latitude > 0 && search.Longitude > 0 && search.Radius > 0) {
            response = response;
        }

        properties.ForEach(p => response.Add(
            _mapper.MapPropertyResponse(p)
        ));

        return response;
    }

    [HttpPost("book")]
    public string Post([FromBody] Property property)
    {
        property.Location.Latitude = Convert.ToDouble("-33." + _random.Next(868563, 898204));
        property.Location.Longitude = Convert.ToDouble("151." + _random.Next(179171, 242557));

        _dbContext.Properties.Add(property);
        _dbContext.SaveChanges();

       return "Created";
    }
}