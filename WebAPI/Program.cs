using EFApplication.Repository;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repository;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register  DbContext
var ConnectionString = builder.Configuration.GetConnectionString("WebAppConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddTransient<IPersonRepo, PersonRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors-origin",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
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

app.UseCors("cors-origin");

app.MapControllers();

app.Run();
