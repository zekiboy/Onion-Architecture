using Microsoft.OpenApi.Models;
using OnionArc.Application;
using OnionArc.Infrastructure;
using OnionArc.Mapper;
using OnionArc.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddInfrastructureServices();

builder.Services.AddCustomMapper();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnionArc.Api", Version = "v1" });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//
app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();

