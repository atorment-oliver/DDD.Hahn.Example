using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});
builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", app =>
        {
            app.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers()
    .AddMvcOptions(options =>
    {
        options.InputFormatters.Insert(
            0,
            new DDD.WebApi.JsonStringInputFormatter());
    });
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ddd.webapi-1 v1"));
}

app.UseCors("PoliticaCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
