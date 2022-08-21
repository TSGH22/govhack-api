using GovHack22API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");  

builder.Services.AddDbContextPool<PropertyContext>(options => 
    options.UseMySql(mySqlConnectionStr, 
        ServerVersion.AutoDetect(mySqlConnectionStr)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GovHack 2022", Version = "v1" });   
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger(o => {
    o.SerializeAsV2 = true;
});
app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.Run();
