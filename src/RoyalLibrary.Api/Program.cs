using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Api.Data;
using RoyalLibrary.Api.Middleware;
using RoyalLibrary.Api.Repositories;
using RoyalLibrary.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

// Add Repository Pattern
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Add Services Layer
builder.Services.AddScoped<IBookService, BookService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// Add global exception handling middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Add Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Royal Library API v1");
    });
}

// Use CORS
app.UseCors("AllowReactApp");

// Map controllers
app.MapControllers();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    await DbInitializer.InitializeAsync(context);
}

app.Run();
