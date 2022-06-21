using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System.Text;
using Vibbraneo.ToDoList.Application.Commands.UserManager;
using Vibbraneo.ToDoList.Domain.Interface.Repositories;
using Vibbraneo.ToDoList.Domain.Interface.Services;
using Vibbraneo.ToDoList.Infraestrutura.Auth;
using Vibbraneo.ToDoList.Infraestrutura.Persistence;
using Vibbraneo.ToDoList.Infraestrutura.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;

});

builder.Services.AddSwaggerGen(c =>
{
    #region Autenthication With Bearer
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Vibbraneo.API",
        Version = "v1",
        Description = "Test project for Vibbraneo in .NET 6",
        Contact = new OpenApiContact
        {            
            Name = "Gelvane Nascimento Silva",
            Email = "gelvane.silva@outlook.com"
        }
    });

    var xmlFile = $"Vibbraneo.ToDoList.Api.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the schema Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

    #endregion
});

#region Context
var _connectionStringToDoList = builder.Configuration.GetConnectionString("TODOLIST_CONNECTIONSTRING");
builder.Services.AddDbContext<ToDoListContext>(
    options => options.UseSqlServer(_connectionStringToDoList));
#endregion

#region DependencyInjection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IListRepository, ListRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
#endregion

#region Mediator
builder.Services.AddMediatR(typeof(LoginCommand));
#endregion

#region CORS
builder.Services.AddCors();
#endregion

#region Authentication
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = builder.Configuration["AuthenticationSettings:Issuer"],
                      ValidAudience = builder.Configuration["AuthenticationSettings:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["AuthenticationSettings:Key"]))
                  };
              });
#endregion

var app = builder.Build();

app.UseApiVersioning();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseSwagger();
app.UseSwaggerUI();


#region CORS
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
#endregion

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
