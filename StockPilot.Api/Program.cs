using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // For Swagger configuration
using StockPilot.Api.Application.Authentication.Commands;
using StockPilot.Api.Application.Mappings;
using StockPilot.Api.Extensions;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;
using StockPilot.Infrastructure.Data;
using StockPilot.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


// Dependency Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
//// Add AutoMapper 
builder.Services.AddAutoMapper(typeof(SocieteProfile));
builder.Services.AddAutoMapper(typeof(VilleProfile));
builder.Services.AddAutoMapper(typeof(RegionProfile));
builder.Services.AddAutoMapper(typeof(ClientProfile));
builder.Services.AddAutoMapper(typeof(SiteProfile));
builder.Services.AddAutoMapper(typeof(OperateurProfile));

// JWT Authentication
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddJwtAuthentication(builder.Configuration);

// Adds a custom CORS (Cross-Origin Resource Sharing) policy based on configuration.
builder.Services.AddCustomCorsPolicy(builder.Configuration);

// Add controllers
builder.Services.AddControllers();

// Swagger with JWT Support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
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

// Use Authentication and Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCustomCors(builder.Configuration);

app.Run();
