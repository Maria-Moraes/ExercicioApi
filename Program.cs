using Microsoft.EntityFrameworkCore;
using Exercicio01.Data;
using Exercicio01.Repositorio.Interfaces;
using Exercicio01.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Carregar config antes de usar
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPedidosProdutosRepositorio, PedidosProdutosRepositorio>();
builder.Services.AddScoped<IPedidosRepositorio, PedidosRepositorio>();
builder.Services.AddScoped<ICategoriasRepositorio, CategoriasRepositorio>();
builder.Services.AddScoped<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();

// Agora a configuração já foi carregada
builder.Services.AddDbContext<SistemaAtividadeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Banco"))
);


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