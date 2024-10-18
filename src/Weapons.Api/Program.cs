using Weapons.Api.Endpoints;
using Weapons.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddProblemDetails();
builder.Services.AddApplication();

var app = builder.Build();

app.AddWeaponEndpoint();


app.Run();