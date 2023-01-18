using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFÝnder.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService, HotelManager>();
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();


builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "Hotels API";
        doc.Info.Version = "1.0.0";

    });
});

//static IHostBuilder CreateHostBuilder(string[] args) =>
//Host.CreateDefaultBuilder(args)
//.ConfigureLogging(conf =>
//{
//    conf.ClearProviders();
//    conf.AddDebug();
//    conf.AddConsole();
//});

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseOpenApi();
app.UseSwaggerUi3();


app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
//app.UseMiddleware<RequestResponseMiddleware>();
app.MapControllers();

app.Run();
