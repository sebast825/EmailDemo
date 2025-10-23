


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

await emailService.SendUserNotificationAsync(
    configuration["EmailSettings:DefaultRecipient"],
    configuration["EmailSettings:DefaultSubject"],
    configuration["EmailSettings:DefaultTextBody"]);


Console.WriteLine("Message Sent!");
