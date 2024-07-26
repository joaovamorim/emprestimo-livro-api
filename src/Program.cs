using EMPRESTIMO.LIVROS.Interfaces;
using EMPRESTIMO.LIVROS.Mappings;
using EMPRESTIMO.LIVROS.Models;
using EMPRESTIMO.LIVROS.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

builder.Services.AddDbContext<EmprestimoLivroContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
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
