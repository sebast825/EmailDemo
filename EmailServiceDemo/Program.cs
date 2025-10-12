


using Core.Interface;
using EmailServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


services.AddSingleton<IConfiguration>(configuration);
services.AddScoped<EmailOptions, SmtpService>();

var provider = services.BuildServiceProvider();

var emailService = provider.GetRequiredService<EmailOptions>();

await emailService.HelloEmailSend("test@gmail.com");


Console.WriteLine("Hello, World!");
