using Microsoft.EntityFrameworkCore;
using RettioAPI.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RettioContext>(
    options => options.UseSqlite("Data Source=Databases/RettioDb.db")
);

builder.Services.AddCors(
    options => {
        options.AddPolicy("AllowAll",
        policies => policies
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
    }
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseStaticFiles();

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
