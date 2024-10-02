
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Cayetano.Inmobiliaria.Application.Interface;
using Cayetano.Inmobiliaria.Application.Main;
using Cayetano.Inmobiliaria.Domain.Core;
using Cayetano.Inmobiliaria.Domain.Interface;
using Cayetano.Inmobiliaria.Infrastructure.Data;
using Cayetano.Inmobiliaria.Infrastructure.Interface;
using Cayetano.Inmobiliaria.Infrastructure.Repository;
using Cayetano.Inmobiliaria.Services.WebApi.Helpers;
using Cayetano.Inmobiliaria.Transversal.Common;
using Cayetano.Inmobiliaria.Transversal.Mapper;
using System.Text;
using static Cayetano.Inmobiliaria.Services.WebApi.Helpers.AppSettings;

var builder = WebApplication.CreateBuilder(args);

// Configurar la sección de JWTSettings
var jwtSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<JWTSettings>(jwtSettings);


// Configurar servicios de CORS
builder.Services.AddCors(options =>
{
    var corsSettings = builder.Configuration.GetSection("CorsSettings");
    var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>();
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(allowedOrigins)
               .WithHeaders(corsSettings["AllowedHeaders"].Split(','))
               .WithMethods(corsSettings["AllowedMethods"].Split(','))
               .AllowCredentials();
    });
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CAYETANO.INMOBILIARIA",
        Description = "Arquitectura CAYETANO.INMOBILIARIA",
        Contact = new OpenApiContact
        {
            Name = "Robinson Anticona",
            Email = "sprav1993@gmail.com",
            Url = new Uri("https://example.com/contact"),
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT"),
        },
        TermsOfService = new Uri("https://example.com/terms"),
    });

    // Configurar el esquema de seguridad JWT en Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Ingrese el token JWT en el encabezado de autorización usando el esquema Bearer.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // Esquema de seguridad Bearer
        BearerFormat = "JWT", // Formato del token
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    // Requiere un esquema de seguridad por defecto (puede ser personalizado)
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});


// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingsProfile).Assembly);

// Configuración de servicios MVC
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Opcional: mantener el nombre original de las propiedades
    });

// Registros singleton, scoped, etc.
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<IInmueblesApplication, InmueblesApplication>();
builder.Services.AddScoped<IInmueblesDomain, InmueblesDomain>();
builder.Services.AddScoped<IInmueblesRepository, InmueblesRepository>();

builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

var jwtOptions = jwtSettings.Get<JWTSettings>();

var key = Encoding.ASCII.GetBytes(jwtOptions.Secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtOptions = jwtSettings.Get<JWTSettings>();
    var key = Encoding.ASCII.GetBytes(jwtOptions.Secret);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtOptions.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userId = int.Parse(context.Principal.Identity.Name);
            // Aquí puedes realizar acciones adicionales después de la validación del token
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Opcional: Cambia a string.Empty para hacer que Swagger UI sea la página de inicio
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware de CORS
app.UseCors();

// Middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapa de los controllers
app.MapControllers();
app.Run();
