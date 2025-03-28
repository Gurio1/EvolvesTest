using FastEndpoints;
using FastEndpoints.Swagger;
using SimpleApp;
using SimpleApp.Database;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints()
    .SwaggerDocument(o => o.ShortSchemaNames = true);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5221); // Listen on all IPs, on port 5221
});

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(config.GetValue<string>("Database:ConnectionString")!));
builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.UseFastEndpoints()
    .UseSwaggerGen();

app.UseMiddleware<ExecutionTimeMiddleware>();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();