using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using lab4.Application;
using lab4.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(options =>
    {
        var modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<Author>("Authors");
        modelBuilder.EntitySet<Book>("Books");

        options.EnableQueryFeatures();  
        options.AddRouteComponents("odata", modelBuilder.GetEdmModel());
    });

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "OData API", Version = "v1" });
    c.OperationFilter<ODataOperationFilter>();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData API v1");
});

app.UseAuthorization();
app.MapControllers();
app.Run();
