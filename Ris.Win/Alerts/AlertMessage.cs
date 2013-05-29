namespace Rs.Dnevnik.Ris.Win.Alerts
{
    public class AlertMessage
    {
        public string Message { get; set; }

        public AlertMessageType MessageType { get; set; }

        public AlertMessage(string message, AlertMessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }
}