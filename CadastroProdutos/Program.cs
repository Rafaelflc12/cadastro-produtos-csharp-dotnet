
using Contratos;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);
builder.Services.AddSingleton<Entidade.configuracao.MeuBanco>();

builder.Services.AddScoped<IRepositorioWrapper, RepositorioWrapper>();
builder.Services.AddScoped<IFornecedorRepositorio, ServiceFornecedor>();
builder.Services.AddScoped<IProdutoRepositorio, ServiceProduto>();
builder.Services.AddScoped<IPedidoRepositorio, ServicePedido>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => 
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
