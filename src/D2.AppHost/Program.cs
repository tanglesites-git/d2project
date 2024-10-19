var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Weapons_Api>("weapons-api");

builder.Build().Run();
