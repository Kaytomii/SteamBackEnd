
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Mapping;
using Steam.Application.Validators;
using Steam.Infrastructure.Configuration;
using Steam.Infrastructure.Data;
using Steam.Infrastructure.Repositories;
using Steam.Infrastructure.Services;
using Steam.Application.Interfaces.Services;
using Steam.Application.Services;

namespace Steam.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SteamDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
            });
            // Add services to the container.
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

            builder.Services.AddControllers();

            //===============================REPOSITORY===============================

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IMediaRepository, MediaRepository>();
            builder.Services.AddScoped<ISystemRequirementsRepository, SystemRequirementsRepository>();
            builder.Services.AddScoped<IAchievementRepository, AchievementRepository>();

            //===============================SERVICES===============================
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJWTService, JWTService>();


            builder.Services.AddAutoMapper(_ => { }, typeof(SteamProfile).Assembly);
            builder.Services.AddValidatorsFromAssemblyContaining<GameCreateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<MediaCreateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<SystemRequirementsCreateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserCreateValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AchievementCreateValidator>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
