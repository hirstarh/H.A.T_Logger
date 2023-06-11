using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Net.Security;
using fileWriter;


namespace EmailMessage
{ 
    public class emailMessage
    {
        string smtp_Server = "smtp.gmail.com";
        int port_No = 587;
       string from_Address = "hirstarh@gmail.com";
        string smtp_Password = "oqee xrsc mzwd hnwq";
        string smtp_User = "ahirst";
        string to_Address = "andrewh@arhsvcs.com";

        // Subject and body of email
        string subject = "H.A.T logging status update";
        string body = "Good day to you Andrew and I hope your day is going well, attached is the txt. file of users that have recently logged into HAT in the last day";

        public void sendMessage()
        {
            // Create the new message
            
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from_Address);
            message.To.Add(to_Address);
            message.Subject = subject;
            message.Body = body;

            //Set up the sending of the email

            SmtpClient smtpClient = new SmtpClient(smtp_Server,port_No);

            smtpClient.Timeout = 5000;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from_Address, smtp_Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            
            //Set up/add attachement and read into the message/MemoryStream

            string filePath_Attachment = "F:\\C# Development\\HAT-Log-Results\\Log.txt";
            MemoryStream pathStream = new MemoryStream(File.ReadAllBytes(filePath_Attachment));

            message.Attachments.Add(new Attachment(pathStream, "Log.txt","text/plain"));

            // Stop error messages about the certificate being invalid, it is not
            //emailMessage.turnoff_cert_security(); 


            // Now send the email
            try
            {
                smtpClient.Send(message);
                Console.Write("Success!!, the email was sent ok");
                
                
            }
            
            catch (Exception ex)
            {

                FileWriter.errorMessages(ex.Message);
               
                
            } 
            
            


        }
      /*   static void turnoff_cert_security()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        } */

    }

    
}
