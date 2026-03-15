using Microsoft.EntityFrameworkCore;
using TodoApp.Application.DependencyInjection;
using TodoApp.Repository.DependencyInjection;
using TodoApp.Repository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services
    .AddApplication()
    .AddRepository();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapGet("/", () =>
{
    var a = 2;
    var b = 2;
    var c = a + b;
    return $"Hello World! {c}";
});

app.Run();
