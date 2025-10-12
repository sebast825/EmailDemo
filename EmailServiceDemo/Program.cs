


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
services.AddScoped<SmtpSender>();
var provider = services.BuildServiceProvider();

var emailService = provider.GetRequiredService<EmailOptionI>();

await emailService.HelloEmailSend(configuration["CorreoSettings:EmailDestino"]);


Console.WriteLine("Hello, World!");
