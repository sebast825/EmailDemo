
# EmailServiceDemo

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
├─ EmailServiceDemo.Console/

```

