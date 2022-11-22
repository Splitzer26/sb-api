using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SBAPI.API.Extensions;
using SBAPI.Application;
using SBAPI.Application.Repository;
using SBAPI.Domain;
using SBAPI.Infraestructure.Repository;
using SBAPI.Infraestructure;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services
    //.AddInfraestructure(builder.Configuration);
    builder.Services.AddCors();
    builder.Services.AddControllers();
    //builder.Services.AddDbContext<SmartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddApplicationLayer(builder.Configuration);
    builder.Services.AddApiVersioningExtension();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Smart Business API",
            Description = "Una API web de ASP.NET Core para gestionar el e-commerce y ventas de Smart Business S. de R.L. del lado del cliente y administrativo ",
            Contact = new OpenApiContact
            {
                Name = "Contacto",
                Url = new Uri("https://github.com/splitzer")
            },
        });
        // using System.Reflection;
        //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });
}
builder.Services.AddDbContext<SmartContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
builder.Services.AddTransient(typeof(IRepositoryAsync<>), typeof(CustomRepositoryAsync<>));

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
     app.UseErrorHandlingMiddleware();
    app.UseAuthentication();
    app.UseAuthorization();
}


app.Run();
// Configure the HTTP request pipeline.








