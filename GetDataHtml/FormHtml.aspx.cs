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
            string to = string.Empty, 
                    subject = string.Empty, 
                    cc = string.Empty, 
                    from = string.Empty;

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/MailList.xml"));
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Emails/email");

            foreach(XmlNode xmlNode in nodeList)
            {
                from = xmlNode.SelectSingleNode("from").InnerText;
                to = xmlNode.SelectSingleNode("to").InnerText;
                cc = xmlNode.SelectSingleNode("cc").InnerText;
                subject = xmlNode.SelectSingleNode("subject").InnerText;
            }

            string body = "";
            var mailNew = new MailMessage(from, to, subject, body);

            string[] toCopies = cc.Split(',');
            foreach (string toCopy in toCopies)
            {
                mailNew.CC.Add(new MailAddress(toCopy));
            }

            mailNew.Subject = subject;
            mailNew.Body = body;
            mailNew.IsBodyHtml = true;
            mailNew.Priority = MailPriority.High;

            var ss = new SmtpClient
            {
                Host = "smtpout.secureserver.net",
                Port = 3535, // https://mx.godaddy.com/help/what-do-i-do-if-i-have-trouble-connecting-to-my-email-account-319
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("no-reply@securepaycc.com", "123456")
            };

            ss.Send(mailNew);
        }
    }
}