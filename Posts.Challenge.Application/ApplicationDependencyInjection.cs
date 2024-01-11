using Posts.Challenge.Application.Services.Jwt;
using Posts.Challenge.Application.Services.Login;
using Posts.Challenge.Application.Services.User;
using Posts.Challenge.Application.Validators;
using Posts.Challenge.Domain.Configuration.Jwt;
using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Interfaces.Services.Jwt;
using Posts.Challenge.Domain.Interfaces.Services.Login;
using Posts.Challenge.Domain.Interfaces.Services.User;
using Posts.Challenge.Domain.Requests;
using Posts.Challenge.Domain.Responses;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Posts.Challenge.Domain.Entities.Post;
using Posts.Challenge.Domain.Interfaces.Services.Post;
using Posts.Challenge.Application.Services.Post;
using Posts.Challenge.Domain.Requests.Post;

namespace Posts.Challenge.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddServicesResolvers(this IServiceCollection services)
        {
            services.AddScoped<IJwtProviderService, JwtProviderService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();

            return services;
        }

        public static IServiceCollection AddServicesMapping(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserResponse>();
                cfg.CreateMap<UserRegisterRequest, UserEntity>();
                cfg.CreateMap<PostRequest, PostEntity>();

            }).CreateMapper());

            return services;
        }

        public static IServiceCollection AddServicesValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserRegisterRequest>, UserRegisterValidator>();
            services.AddScoped<IValidator<PostRequest>, PostRequestValidator>();

            return services;
        }


        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection("JWT");
            services.Configure<JWTConfiguration>(jwtConfiguration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.GetSection("EmitedBy").Value,
                    ValidAudience = jwtConfiguration.GetSection("ValidatedIn").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.GetSection("Secret").Value))
                });

            return services;
        }
    }
}
