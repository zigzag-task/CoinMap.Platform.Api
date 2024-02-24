using Asp.Versioning;
using CoinMap.Platform.Api.ExceptionHandling;
using CoinMap.Platform.Api.Extensions.Service;
using CoinMap.Platform.Api.Swagger;
using CoinMap.Platform.Infrastructure.Extensions.Service;
using CoinMap.Platform.Middleware.Extensions.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

#region Add services to the container

builder.Services.AddDdManagement(configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddUseCases();
builder.Services.AddRepositoryPattern();
builder.Services.AddProxyPattern();

builder.Services.AddSwaggerGenOptions();
builder.Services.AddSwaggerGen(options =>
{
    // Add a custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
}).AddApiExplorer(options => {
    // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
    // note: the specified format code will format the version as "'v'major[.minor][-status]"
    options.GroupNameFormat = "'v'VVV";

    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
    // can also be used to control the format of the API version in route templates
    options.SubstituteApiVersionInUrl = true;
}).AddMvc();

builder.Services.AddAutoMapperProfiles();
builder.Services.AddMiddlewareAutoMapperProfiles();

#region Jwt configuration starts here

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["JWT:Issuer"],
        ValidAudience = configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = async (context) => {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            context.Error = "Request Access Denied";

            if (context.AuthenticateFailure != null)
            {
                if (context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
                {
                    var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                    context.ErrorDescription = "The token has expired";
                }
                else context.ErrorDescription = "Token validation has failed";

            }
            else
            {
                context.ErrorDescription = "Òhe provision of a valid token is required";
            }

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Message = context.Error,
                Description = context.ErrorDescription
            }));
        }

    };
});
#endregion

#endregion
var app = builder.Build();

#region Configure the HTTP request pipeline.

app.UseFactory();
app.UseMiddlewareFactory();
app.UseMiddleware<ExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        //var descriptions = app.DescribeApiVersions().Reverse(); /*will display all api version in reverse order*/

        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, $"Timeflow API {name}");
        }
    });
    app.UseSwagger(options => { options.RouteTemplate = "api-docs/{documentName}/docs.json"; });
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "api-docs";
        foreach (var description in app.DescribeApiVersions())
            options.SwaggerEndpoint($"/api-docs/{description.GroupName}/docs.json", description.GroupName.ToUpperInvariant());
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();
