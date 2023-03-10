using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Middlware;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>()
;app.UseCors(builder =>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var servises = scope.ServiceProvider;
try{
    var context = servises.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await seed.SeedUsers(context);
}catch(Exception ex){
 var logger = servises.GetService<ILogger<Program>>();
 logger.LogError(ex,"Error occured during Migration");
}
app.Run();
