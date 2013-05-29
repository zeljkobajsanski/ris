using System.Net.Mail;
using OpenPop.Pop3;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Services
{
    public class OpenPopService : IPop3Service
    {
        private readonly Pop3Client fClient = new Pop3Client();

        public void Connect(string server, int port, bool ssl)
        {
            fClient.Connect(server, port, ssl);
        }

        public void Authenticate(string username, string password)
        {
            fClient.Authenticate(username, password);
        }

        public int GetMessageCount()
        {
            return fClient.GetMessageCount();
        }

        public MailMessage GetMessage(int messageNumber)
        {
            var msg = fClient.GetMessage(messageNumber + 1);
            var msgPart = msg.FindFirstPlainTextVersion();
            if (msgPart == null) return null;
            var mail = msg.ToMailMessage();
            var from = mail.From.Address;
            var body = msgPart.BodyEncoding.GetString(msgPart.Body);
            return new MailMessage()
            {
                From = new MailAddress(from),
                Subject = mail.Subject,
                Body = body
            };
        }

        public void DeleteMessage(int messageNumber)
        {
            fClient.DeleteMessage(messageNumber + 1);
            //fClient.DeleteAllMessages();
        }

        public void Dispose()
        {
            fClient.Dispose();
        }
    }
}