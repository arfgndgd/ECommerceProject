﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public static class MailSender
    {
        public static void Send(string receiver, string password = "ahmet.1966", string body = "Test mesajı", string subject = "Email Testi", string sender = "ahmetgundo.66@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Email işlemleri Smpt'ne göre yapılır.
            //****Kullandığımız mail hesabının başka uygulamalar tarafından mesaj gönderme özelliği açılmalı. (3. parti yazılımlar)
            SmtpClient smpt = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smpt.Send(message);
            }
        }
    }
}
