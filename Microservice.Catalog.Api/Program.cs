using Microservice.Catalog.Api.Options;
using Microservice.Catalog.Api.Repositories;
using MongoDB.Driver;

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



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

