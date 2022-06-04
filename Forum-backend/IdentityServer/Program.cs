using IdentityServer.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(IdConfig.ApiResources)
    .AddInMemoryApiScopes(IdConfig.ApiScopes)
    .AddInMemoryClients(IdConfig.Clients)
    .AddInMemoryIdentityResources(IdConfig.IdentityResources)
    .AddTestUsers(IdConfig.TestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.Run();
