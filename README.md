
# Modular Email Sender

Is a C# console application that allows sending emails via SMTP in a modular and scalable way.

The application can send different types of predefined emails, such as welcome messages or personalized notifications. The templates and SMTP configuration are decoupled to make maintenance and testing easier.

The project is organized in layers: Core (business models and templates), Services (email sending logic), and Console (entry point).

An appsettings.json file is required to configure the email settings (SMTP, email, and password). The project uses dependency injection to instantiate SmtpSender and EmailService.

```
EmailServiceDemo/
├─ Core/
│   ├─ Entities/
│   ├─ Templates/
│   ├─ Interfaces/
├─ Services/
│       ├─ SmtpSender.cs 
│       └─ EmailService.cs
│       └─ PostmarkSender.cs
├─ EmailServiceDemo.Console/
│       ├─ appSettingsExample.cs
│       ├─ program.cs


```


- **Core** – Business models, templates, and interfaces  
- **Services** – SMTP sender and email service logic  
- **Console** – Application entry point  

## Configuration

An `appsettings.json` file is required to set up SMTP credentials and sender info.  

> **Note:** The `appsettings.json` file should be located inside the **EmailServiceDemo.Console** project, as this is the entry point of the application. The settings will be loaded from there at runtime.


## Usage

- Configure appsettings.json
- Run the console project
  
```
dotnet run --project EmailServiceDemo
```
- The app will send predefined or custom emails depending on configuration


## Switching Between Email Senders

The application supports multiple email providers (SMTP and Postmark).

To switch between them:

1. **In `EmailOption.cs`** – Change the injected sender class (`SmtpSender` or `PostmarkSender`) used inside the constructor.
2. **In `Program.cs`** – Update the dependency injection registration to match the chosen sender.

Example:
```csharp
// For Postmark
services.AddScoped<IEmailSender, PostmarkSender>();

// For SMTP
services.AddScoped<IEmailSender, SmtpSender>();
```

## Send Messages

Use the method you need dependig of wich message want to send.

```c#
await emailService.SendUserNotificationAsync(
    configuration["EmailSettings:DefaultRecipient"],
    configuration["EmailSettings:DefaultSubject"],
    configuration["EmailSettings:DefaultTextBody"]);

await emailService.Welcome(configuration["EmailSettings:DefaultRecipient"]);

```

## Email Templates

Check EmailTemplatesOptions for existing template types.

To add a new template:

- Create a method in EmailTemplatesOptions that returns an EmailTemplateContent object.
- Add a corresponding method in EmailOption to send the new template.
- Create an interface if you need to expose it publicly.


## Postmark Configuration (Optional)

To enable sending emails via Postmark:

1. Create a free account on <a href="https://postmarkapp.com/" target="_blank">Postmark</a>.
2. Verify a sender email or domain.
3. Obtain your API Key and configure it in the project.

