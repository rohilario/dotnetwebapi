using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dotnetwebapi.Data;
using dotnetwebapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Registra os servicos
builder.Services.AddScoped<IUserService, Userervice>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

// Cria o context com o banco
// To-Do: Migrar para o arquivo de dbcontext
var connectionStringMysql = builder.Configuration.GetConnectionString("connectionMysql");
builder.Services.AddDbContext<APIDbContext>(options =>
    options.UseMySql(connectionStringMysql
    ,ServerVersion.Parse("8.2.0-Mysql")
    )
);

// Adiciona servico ao container.
builder.Services.AddControllers();

//Aplica Swagger para documentar a API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Build app
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