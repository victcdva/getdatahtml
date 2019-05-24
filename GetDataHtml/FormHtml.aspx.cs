using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.Net.Mail;

namespace GetDataHtml
{
    public partial class FormHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void send_Click(object sender, EventArgs e)
        {
            string to = string.Empty, subject = string.Empty, cc = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/MailList.xml"));
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Emails/email");

            foreach(XmlNode xmlNode in nodeList)
            {
                to = xmlNode.SelectSingleNode("to").InnerText;
                cc = xmlNode.SelectSingleNode("cc").InnerText;
                subject = xmlNode.SelectSingleNode("subject").InnerText;
            }

            SendEmail(to, "vicctor.cordova@gmail.com", subject, "TESSSST", cc);                    
        }

        protected void SendEmail(string to, string from,string subject, string body, string cc)
        {            
            string[] toCopies = to.Split(';');
            MailMessage mailNew = new MailMessage();
            mailNew.From = new MailAddress(from);

            foreach (string toCopy in toCopies)
            {
                mailNew.To.Add(new MailAddress(toCopy));
            }

            mailNew.Bcc.Add(cc);
            mailNew.Subject = subject;
            mailNew.Body = body;
            mailNew.IsBodyHtml = true;
            mailNew.Priority = MailPriority.Normal;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("theslapboy@gmail.com", "ateosolraiar");
        }
    }
}