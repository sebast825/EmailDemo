


using Core.Interface;
using EmailServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


services.AddSingleton<IConfiguration>(configuration);
services.AddScoped<IEmailOption, EmailOption>();
services.AddScoped<IEmailSender,SmtpSender>();
var provider = services.BuildServiceProvider();

var emailService = provider.GetRequiredService<IEmailOption>();

//await emailService.Welcome(configuration["CorreoSettings:EmailDestino"]);
await emailService.SendUserNotificationAsync(configuration["PostmarkSettings:EmailDestino"], "Carmelio", "Este es un mensaje importante!");


Console.WriteLine("Message Sent!");
