using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dotnetwebapi.Data;
using dotnetwebapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using NuGet.Protocol.Core.Types;
using System.Buffers.Text;
using System.Composition;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Registra os servicos
builder.Services.AddScoped<IUserService, Userervice>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

// Adiciona Midleware de autenticacao
var key = Encoding.ASCII.GetBytes(dotnetwebapi.Key.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Cria o context com o banco
// To-Do: Migrar para o arquivo de dbcontext
var connectionStringMysql = builder.Configuration.GetConnectionString("connectionMysql");
builder.Services.AddDbContext<APIDbContext>(options =>
    options.UseMySql(connectionStringMysql
    ,ServerVersion.Parse("8.2.0-Mysql")
    )
);
// Adiciona a Conexao do MongoDB
var mongoClient = new MongoClient(builder.Configuration["ConnectionStrings:MongoDB"]);
var database = mongoClient.GetDatabase("db_dotnetwebapi");
builder.Services.AddSingleton<IMongoDatabase>(database);

// Adiciona servico ao container.
builder.Services.AddControllers();

// Aplica Swagger para documentar a API.
builder.Services.AddEndpointsApiExplorer();
// Ajustar Swagger para ter o Authorize e demais configs
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
        },
        new List<string>()
        }

});
    x.SwaggerDoc
        ("v1", new OpenApiInfo()
        {
            Title = "Swagger - App .NET"
            ,
            Version = "v1"
            ,
            Description = "API RESTful com .NET 7."
        });
});


// Add Serilog
const string logPath = "../log/serilog-dotnetwebapi.log";
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Build app
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();