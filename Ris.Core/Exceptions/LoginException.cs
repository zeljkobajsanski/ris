using System;

namespace Rs.Dnevnik.Ris.Core.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}