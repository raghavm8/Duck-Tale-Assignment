using Assignment.DBHelper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Allcors",
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allcors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
