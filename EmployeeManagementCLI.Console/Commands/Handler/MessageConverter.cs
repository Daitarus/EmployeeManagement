using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Domain.Models;

namespace EmployeeManagementCLI.Console.Commands.Handler
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
