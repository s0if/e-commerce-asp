using E_commerce_core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Infrastructure.Service
{
    public class EmailSetting
    {
        public static void SendEmail(EmailDTOs Email)
        {
            SmtpClient client=  new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("saifalkomi@gmail.com", "cgox mtoe rnuj fthq");
            client.Send("saifalkomi@gmail.com",Email.Recivers,Email.Subject,Email.Body);
           
        }
    }
}
