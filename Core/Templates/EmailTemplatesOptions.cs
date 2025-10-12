using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Templates
{
    public static class EmailTemplatesOptions
    {
        public static EmailTemplateContent Welcome =>
            new EmailTemplateContent("Bienvenido!", "<p>¡Bienvenido a nuestro sitio! Explora y descubre todo lo que ofrecemos.</p>");
        public static EmailTemplateContent Notifiaction(string userName, string message)
        {
            string subject = $"Hola {userName}, tienes una nueva notificación";
            string body = $@"
            <p>Hola {userName},</p>
            <p>{message}</p>
            <p>¡Gracias por usar nuestro servicio!</p>";
            return new EmailTemplateContent(subject, body);
        }
    }
}
