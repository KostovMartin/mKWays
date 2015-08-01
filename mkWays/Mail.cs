using System;
using System.Net;
using System.Net.Mail;
using mkWays.Models;

namespace mkWays
{
    public static class Mail
    {
        public static void SendEmail(MailModel e)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(e.Email);
                    mail.To.Add(new MailAddress("centrino2duo@gmail.com"));
                    mail.Subject = "Email from " + e.Name;
                    mail.Body = e.Message;
                    mail.IsBodyHtml = true;

                    //validate the certificate
                    ServicePointManager.ServerCertificateValidationCallback =
                        (s, certificate, chain, sslPolicyErrors) => true;

                    try
                    {
                        var client = new SmtpClient("smtp.mail.yahoo.com", 587)
                        {
                            Credentials = new NetworkCredential("centrino2duo@yahoo.com", "Sup3rn@tural"),
                            EnableSsl = true,
                            UseDefaultCredentials = false
                        };
                        client.Send(mail);
                    }

                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }
                }
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    SmtpStatusCode status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        // Response.Write("Delivery failed - retrying in 5 seconds.");
                        //Thread.Sleep(5000);
                    }
                }
            }
            catch (SmtpException Se)
            {
                // handle exception here
                //Response.Write(Se.ToString());
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }
        }
    }
}