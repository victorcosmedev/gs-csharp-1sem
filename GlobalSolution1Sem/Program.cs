using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Application.Services;
using GlobalSolution1Sem.Configurations;
using GlobalSolution1Sem.Domain.Interfaces;
using GlobalSolution1Sem.Infrastructure.Data.AppData;
using GlobalSolution1Sem.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(option => {
    option.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});


builder.Services.AddTransient<IEnderecoService, EnderecoService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSwaggerGen(conf => {

    conf.EnableAnnotations();
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
