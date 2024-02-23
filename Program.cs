using BackendTodoCode.Interfaces;
using BackendTodoCode.Models;
using BackendTodoCode.Services;
using BackendTodoCode.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Cliente>());

builder.Services.AddDbContext<TodoCodeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});
builder.Services.AddScoped<IValidator<Cliente>, ClienteValidator>();
builder.Services.AddScoped<ClienteRepository, ClienteService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
