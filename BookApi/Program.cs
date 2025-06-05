////using BookApi.Services;
////using Microsoft.EntityFrameworkCore;
////using BookApi.Entities;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.

////builder.Services.AddControllers();
////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////builder.Services.AddDbContext<BookDbContext>(options =>
////    options.UseNpgsql(
////        builder.Configuration.GetConnectionString("DefaultConnection"),
////        x => x.MigrationsAssembly("BookApi.Entities")
////    )
////);

//////builder.Services.AddDbContext<BookDbContext>(option =>
//////    option.UseNpgsql(
//////        builder.Configuration.GetConnectionString("DefaultConnection"),
//////        b => b.MigrationsAssembly("BookApi.Entities"))); // <- this line is key

//////builder.Services.AddDbContext<BookDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

////builder.Services.AddSingleton<BookService>();

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseAuthorization();

////app.MapControllers();

////app.Run();


//using BookApi.Services;
//using Microsoft.EntityFrameworkCore;
//using BookApi.Entities.Context; // Updated namespace for BookDbContext
//using BookApi.Entities; // For other entity-related classes if needed

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Database Configuration
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//builder.Services.AddDbContext<BookDbContext>(options =>
//    options.UseNpgsql(
//        connectionString,
//        x => x.MigrationsAssembly("BookApi.Entities") // Ensure this matches your project name
//    )
//);

//// Service Registration (changed to Scoped for DbContext compatibility)
//builder.Services.AddScoped<BookService>(); // Changed from Singleton to Scoped

//// Add health checks
//builder.Services.AddHealthChecks()
//    .AddNpgSql(connectionString);

//var app = builder.Build();

//// Configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();

//    // Apply pending migrations in development
//    using (var scope = app.Services.CreateScope())
//    {
//        var dbContext = scope.ServiceProvider.GetRequiredService<BookDbContext>();
//        dbContext.Database.Migrate();
//    }
//}

//app.UseAuthorization();

//// Additional endpoints
//app.MapControllers();
//app.MapHealthChecks("/health");

//app.Run();

using BookApi.Services;
using Microsoft.EntityFrameworkCore;
using BookApi.Entities.Context;
using BookApi.Entities;
using AspNetCore.HealthChecks.NpgSql; // Add this line

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseNpgsql(
        connectionString,
        x => x.MigrationsAssembly("BookApi.Entities")
    )
);

// Service Registration
builder.Services.AddScoped<BookService>();

// Add health checks
builder.Services.AddHealthChecks()
    .AddNpgSql(connectionString); // This will now work

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Apply pending migrations in development
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<BookDbContext>();
        dbContext.Database.Migrate();
    }
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();