using DataAccess.Repositorio;
using Microsoft.EntityFrameworkCore;
using projetoalex.Aplicacao;
using projetoalex.Repositorio;
using projetoalex.Services;
using Projetoalex.Dominio;
using Projetoalex.Repositorio;


var builder = WebApplication.CreateBuilder(args);

// Adicione aplicações
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IProdutosAplicacao, ProdutoAplicacao>();
builder.Services.AddScoped<IOllamaAplicacao, OllamaAplicacao>();



//Adicione repositorio
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IOllamaRepositorio, OllamaRepositorio>();

// IA Ollama
builder.Services.AddHttpClient<OllamaService>();




builder.Services.AddCors(options => 
{
	options.AddDefaultPolicy(builder =>
	{
		builder.WithOrigins("http://localhost:3000")
			.SetIsOriginAllowedToAllowWildcardSubdomains()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services.AddControllers();

builder.Services.AddDbContext<ProjetoalexContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
