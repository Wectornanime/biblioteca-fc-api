using biblioteca_fc_api.Data;
using biblioteca_fc_api.Repositories;
using biblioteca_fc_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkMySQL()
    .AddDbContext<BibiotecaDbContext>(options =>
        options.UseMySQL(
            builder.Configuration.GetConnectionString("MySqlConnection")
        )
    );

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
