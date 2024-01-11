using Microsoft.OpenApi.Models;
using Posts.Challenge.Infrastructure;
using Posts.Challenge.Application;
using Posts.Challenge.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
});

builder.Services.AddCors(options => 
{
    options.AddPolicy("CorsPolicy",
        builder =>
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
        );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira a palavra \"Bearer\" com um espa�o a frente e em seguida o token de autentica��o."
    });
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
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

builder.Services.AddSignalR();

builder.Services.AddPersistenceConfiguration(builder.Configuration.GetConnectionString("MyServer"));

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddRepositoriesResolvers();

builder.Services.AddServicesResolvers();

builder.Services.AddServicesMapping();

builder.Services.AddServicesValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<PostsHub>("posts-hub");

app.Run();
