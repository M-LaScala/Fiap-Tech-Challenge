using Serilog;
using System.Reflection;
using Tech.Challenge.Grupo27.API.Filters;
using Tech.Challenge.Grupo27.API.Telemetria;
using Tech.Challenge.Grupo27.Infrastructure.DI;


var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

var logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Console()
             .WriteTo.File("logs/contatoApp.text", rollingInterval: RollingInterval.Day)
             .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

builder.Services.AddTransient<TelemetryMiddleware>();

// Add services to the container.

var options = new Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore.DbOptions(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("Prefix"));
builder.Services.AddSingleton(options);
builder.Services.AddSqlServerProvider(options);
builder.Services.AddApplication();
builder.Services.AddDomainService();
builder.Services.AddRepository();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => 
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Contato API",
        Description = "API responsável por gerenciar contatos"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
