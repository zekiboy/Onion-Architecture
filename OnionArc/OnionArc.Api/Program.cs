using Microsoft.OpenApi.Models;
using OnionArc.Application;
using OnionArc.Infrastructure;
using OnionArc.Mapper;
using OnionArc.Persistence;
using OnionArc.Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnionArc.Api", Version = "v1", Description = "OnionArc.Api swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "'Bearer' yazdıktan sonra boşluk bırakıp Token'ı giriniz. \r\n\r\n Örneğin: \"Bearer eyadsasa23213hb123hjbas\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
            Array.Empty<string>()

        }
    });
     
});

builder.Services.AddApplicationServices();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCustomMapper();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Exceptions from Application Layer
app.ConfigureExceptionHandlingMiddleware();

app.UseHttpsRedirection();


//
app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();

