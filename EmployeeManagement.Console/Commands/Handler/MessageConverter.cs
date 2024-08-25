using EmployeeManagement.Console.Commands.Handler.Interfaces;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Console.Commands.Handler
{
    public class MessageConverter : IModelConverter<Message, string>
    {
        public string Convert(Message model)
        {
            if(model == null) throw new ArgumentNullException(nameof(model));

            return model.Text;
        }
    }
}
