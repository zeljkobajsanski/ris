using System;
using System.Net.Mail;

namespace Rs.Dnevnik.Ris.Interfaces.Services
{
    public interface IPop3Service : IDisposable
    {
        void Connect(string server, int port, bool ssl);
        void Authenticate(string username, string password);
        int GetMessageCount();
        MailMessage GetMessage(int messageNumber);
        void DeleteMessage(int messageNumber);
    }
}