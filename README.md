
# Email Service Demo

EmailServiceDemo is a C# console application that allows sending emails via SMTP in a modular and scalable way.

The application can send different types of predefined emails, such as welcome messages or personalized notifications. The templates and SMTP configuration are decoupled to make maintenance and testing easier.

The project is organized in layers: Core (business models and templates), Services (email sending logic), and Console (entry point).

An appsettings.json file is required to configure the email settings (SMTP, email, and password). The project uses dependency injection to instantiate SmtpSender and EmailService.

```
EmailServiceDemo/
├─ Core/
│   ├─ Entities/
│   ├─ Templates/
│   ├─ Interfaces/
│   └─ Enums/
├─ Services/
│       ├─ SmtpSender.cs 
│       └─ EmailService.cs
│       └─ PostmarkSender.cs
├─ EmailServiceDemo.Console/

```


- **Core** – Business models, templates, and interfaces  
- **Services** – SMTP sender and email service logic  
- **Console** – Application entry point  

## Configuration

An `appsettings.json` file is required to set up SMTP credentials and sender info.  
Example:

```json
{
  "CorreoSettings": {
    "EmailOrigen": "example@gmail.com",
    "Contrasenia": "your-app-password",
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": 587,
    "EnableSsl": true
  }
}
```
> **Note:** The `appsettings.json` file should be located inside the **EmailServiceDemo.Console** project, as this is the entry point of the application. The settings will be loaded from there at runtime.


## Usage

- Configure appsettings.json
- Run the console project
- The app will send predefined or custom emails depending on configuration


## Switching Between Email Senders

The application supports multiple email providers (SMTP and Postmark).

To switch between them:

1. **In `EmailOption.cs`** – Change the injected sender class (`SmtpSender` or `PostmarkSender`) used inside the constructor.
2. **In `Program.cs`** – Update the dependency injection registration to match the chosen sender.

Example:
```csharp
// For Postmark
services.AddScoped<EmailSenderI, PostmarkSender>();

// For SMTP
services.AddScoped<EmailSenderI, SmtpSender>();
```

## Postmark Configuration (Optional)

To enable sending emails via Postmark:

1. Create a free account on <a href="https://postmarkapp.com/" target="_blank">Postmark</a>.
2. Verify a sender email or domain.
3. Obtain your API Key and configure it in the project.

## Naming Convention for Interfaces

In this project, all interfaces are named with an **`I` suffix** (e.g., `EmailSenderI`, `EmailOptionI`).

Although the standard C# convention uses a leading `I` (e.g., `IEmailSender`), this project follows a trailing `I` pattern for easier discoverability when searching or using autocomplete in large codebases.

