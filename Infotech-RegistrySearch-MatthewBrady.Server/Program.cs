using System;
using InfoTech_Data;
using InfoTech_Data.SearchResultsData;
using InfoTech_RegistrySearch_Domain.SearchOutput;
using InfoTech_RegistrySearch_Domain.Trends;
using Infotech_RegistrySearch_MatthewBrady.Server.Services;
using Infotech_RegistrySearch_MatthewBrady.Server.TestData;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueDev", policy =>
    {
        //policy.WithOrigins("http://localhost:51054")
        //    .AllowAnyHeader()
        //    .AllowAnyMethod();
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();

    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.CommandTimeout(60))
    );



//builder.Services.AddScoped<ISearchResultService, SearchResultsService>();
builder.Services.AddScoped<ISearchApplicationService, SearchApplicationService>();
builder.Services.AddScoped<ISearchHistoryApplicationService, SearchHistoryApplicationService>();
builder.Services.AddScoped<ISearchTrendService, SearchTrendService>();
builder.Services.AddScoped<ISearchResultRepository, SearchResultRepository>();

builder.Services.AddScoped<SeedData, SeedData>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//options =>
//{
//    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Title = "My API",
//        Version = "v1",
//        Description = "API for registry search",
//        Contact = new OpenApiContact
//        {
//            Name = "Your Name",
//            Email = "you@example.com"
//        },
        
//    });
    
//});



var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    //app.MapScalarApiReference();

    app.UseSwagger(c =>
    {
        c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI();
    //c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //    c.RoutePrefix = "swagger";
    //});
}



app.UseCors("AllowVueDev");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
