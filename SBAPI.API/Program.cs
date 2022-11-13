using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SBAPI.API.Errors;
using SBAPI.API.Filters;
using SBAPI.Domain;
using SBAPI.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services
    //.AddInfraestructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddDbContext<SmartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
   // builder.Services.AddSingleton<ProblemDetailsFactory, SBProblemDetailsFactory>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
{
    //app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
       // app.UseAuthorization();
    }
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<SmartContext>();
    dataContext.Database.Migrate();
}
app.Run();
// Configure the HTTP request pipeline.








