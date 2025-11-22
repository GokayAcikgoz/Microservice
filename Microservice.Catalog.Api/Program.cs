using MediatR;
using Microservice.Catalog.Api;
using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Features.Categories.Create;
using Microservice.Catalog.Api.Options;
using Microservice.Catalog.Api.Repositories;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//ValidateDataAnnotations data üzerine requerid yazdýðýmýz attribute'leri kontrol eder.
//ValidateOnStart Uygulama ayaða kalkarken validasyon yapar.
//extensionsa aldýk bunu
//builder.Services.AddOptions<MongoOptions>().BindConfiguration(nameof(MongoOptions)).ValidateDataAnnotations().ValidateOnStart();
builder.Services.AddOptionsExt();

//builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
//{
//    var options = sp.GetRequiredService<MongoOption>();
//    return new MongoClient(options.ConnectionString);
//});

//builder.Services.AddScoped(sp =>
//{
//    var mongoClient = sp.GetRequiredService<IMongoClient>();
//    var mongoOption = sp.GetRequiredService<MongoOption>();

//    return AppDbContext.Create(mongoClient.GetDatabase(mongoOption.DatabaseName));
//});
builder.Services.AddDatabaseServiceExt();

//bunun için ext metot yazacaðýz
//builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddCommonServiceExt(typeof(CatalogAsembly));

var app = builder.Build();


//minimalapi
//bu kod verticalslice a uygun deðil düzelticez bunu.
//app.MapPost("/categories", async (CreateCategoryCommand command, IMediator mediator) =>
//{
//    var result = await mediator.Send(command);
//    return new ObjectResult(result)
//    {
//        StatusCode = result.Status.GetHashCode()
//    };
//});

//category grup ile ilgili tüm endpointler eklenmiþ oldu.
app.AddCategoryGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

