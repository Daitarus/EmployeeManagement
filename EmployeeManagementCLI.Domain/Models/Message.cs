namespace EmployeeManagementCLI.Domain.Models
{
    public class Message
    {
        public ActionStatus Status { get; set; }
        public string Text { get; set; }

        public Message(ActionStatus status, string text)
        {
            Status = status;
            Text = text;
        }
    }

    public enum ActionStatus
    {
        Error,
        Success,
        NotSuccess
    }
}
