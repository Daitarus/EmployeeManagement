using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Models
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
}
