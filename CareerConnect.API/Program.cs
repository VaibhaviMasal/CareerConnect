using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Application.Features.Applications.Services;
using CareerConnect.Application.Features.Authentication.Interfaces;
using CareerConnect.Application.Features.Authentication.Services;
using CareerConnect.Application.Features.Candidates.Interfaces;

using CareerConnect.Application.Features.Interviews.Interfaces;
using CareerConnect.Application.Features.Interviews.Services;
using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Application.Features.Jobs.Services;

using CareerConnect.Application.Features.Recruiters.Interfaces;
using CareerConnect.Application.Features.Resumes.Interfaces;
using CareerConnect.Application.Features.Resumes.Services;
using CareerConnect.Application.Features.Users.Interfaces;
using CareerConnect.Infrastructure.Persistence;
using CareerConnect.Infrastructure.Repositories;
using CareerConnect.Shared.Middleware;
using CareerConnect.Application.Features.Users.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using CareerConnect.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);




// =====================
// DB CONFIG
// =====================
builder.Services.AddDbContext<CareerConnectDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// =====================
// REPOSITORIES
// =====================
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<IResumeRepository, ResumeRepository>();


// =====================
// SERVICES
// =====================
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();
builder.Services.AddScoped<IResumeService, ResumeService>();


// =====================
// JWT AUTHENTICATION 🔐
// =====================
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),

            
            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });


// =====================
// CONTROLLERS
// =====================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });


// =====================
// SWAGGER + JWT SUPPORT
// =====================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your token}"
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
                }
            },
            new string[] {}
        }
    });
});


// =====================
// BUILD APP
// =====================
var app = builder.Build();

// =====================
// DATABASE SEEDING
// =====================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CareerConnectDbContext>();

    await DbSeeder.SeedAsync(context);
}

// =====================
// MIDDLEWARE PIPELINE
// =====================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global exception handler
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

// 🔥 ORDER MATTERS
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

