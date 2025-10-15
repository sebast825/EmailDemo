


using Core.Interface;
using EmailServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


services.AddSingleton<IConfiguration>(configuration);
services.AddScoped<EmailOptionI, EmailOption>();
services.AddScoped<PostmarkSender>();
var provider = services.BuildServiceProvider();

var emailService = provider.GetRequiredService<EmailOptionI>();

//await emailService.Welcome(configuration["CorreoSettings:EmailDestino"]);
await emailService.Notification(configuration["CorreoSettings:EmailDestino"], "Carmelio", "Este es un mensaje importante!");


Console.WriteLine("Message Sent!");
