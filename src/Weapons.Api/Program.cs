using System.Text.Encodings.Web;
using System.Text.Json;
using Weapons.Api;
using Weapons.Api.Endpoints;
using Weapons.Application;
using Weapons.Infrastructure;
using Weapons.Kernal;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHttpLogging(options => { });

var configuration = builder.Configuration;
builder.Services.AddConfiguration<ConnectionStrings>(configuration, ConnectionStrings.SectionName);

builder.Services.AddProblemDetails();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddDatabaseContext(configuration["ConnectionStrings:SQLiteConnection"]!);

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseHttpLogging();

app.AddCreateWeaponEndpoint();
app.AddGetAllWeapons();

app.Run();