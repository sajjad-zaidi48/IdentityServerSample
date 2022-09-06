using IdentityServer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddOperationalStore(options =>
            {
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 30; // interval in seconds
            })
            //.AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients())
            .AddInMemoryApiScopes(Config.GetApiResources());

var app = builder.Build();

app.UseIdentityServer();
app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
