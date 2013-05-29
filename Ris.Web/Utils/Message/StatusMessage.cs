namespace Ris.Web.Utils.Message
{
    public class StatusMessage
    {
        public StatusMessage(string message, StatusMessageType type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; set; }
        public StatusMessageType Type { get; set; }
    }
}