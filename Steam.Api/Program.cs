using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Steam.Api.MiddleWares;
using Steam.Application.Interfaces.Repository;
using Steam.Application.Interfaces.Services;
using Steam.Application.Mapping;
using Steam.Application.Services;
using Steam.Application.Validators;
using Steam.Infrastructure.Configuration;
using Steam.Infrastructure.Data;
using Steam.Infrastructure.Repositories;
using Steam.Infrastructure.Services;

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


            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Steam API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT token"
                });
            });

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

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IMediaService, MediaService>();
            builder.Services.AddScoped<ISystemRequirementsService, SystemRequirementsService>();
            builder.Services.AddScoped<IAchievementService, AchievementService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IProviderService, ProviderService>();


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
            app.UseMiddleware<RequestTimerMiddleware>();
            app.UseMiddleware<CancellationTokenHandleMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}
