﻿using Celler.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Celler.Infraestrutura.Servicos
{
    public class EnviarEmail
    {
        public EnviarEmail()
        {

        }

        public void enviar(String email, MensagemModel model)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("cellercwi@gmail.com");
                mail.To.Add(email);
                mail.Subject = model.Assunto;
                mail.Body = model.Texto;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cellercwi@gmail.com", "cellercwi.10");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}