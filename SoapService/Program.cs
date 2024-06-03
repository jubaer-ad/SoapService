using SoapCore;
using SoapService.Services;
using static SoapService.Models.BlackServiceContract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IBlackService, BlackService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSoapEndpoint<IBlackService>("/BlackService.asmx", new SoapEncoderOptions());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
