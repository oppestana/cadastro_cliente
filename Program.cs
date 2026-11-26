using cadastro_clientes.Data;
using cadastro_clientes.Repositories;
using cadastro_clientes.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ConexaoBanco>();
builder.Services.AddScoped<ClientesRepository>();
builder.Services.AddScoped<ClientesService>();

var app = builder.Build();

app.MapControllers();

app.Run();