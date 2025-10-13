
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
