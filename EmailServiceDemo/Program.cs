


using Core.Interface;
using EmailServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


services.AddSingleton<IConfiguration>(configuration);
services.AddScoped<SendEmailI, SmtpService>();

var provider = services.BuildServiceProvider();

var emailService = provider.GetRequiredService<SendEmailI>();

await emailService.SendAsync("test@gmail.com","a","b");


Console.WriteLine("Hello, World!");
