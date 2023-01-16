using UserRegistrationApi.Application.Data;
using Microsoft.EntityFrameworkCore;
using UserRegistrationApi.Atributes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddDbContext<ApplicationDbContext>();
Scoped.Add(builder.Services);

var myConnection = builder.Configuration.GetConnectionString("MyConnection");

if(!string.IsNullOrEmpty(myConnection))
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(myConnection, ServerVersion.AutoDetect(myConnection)));

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
