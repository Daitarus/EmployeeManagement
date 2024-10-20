﻿using EmployeeManagementCLI.Domain.Models;

namespace EmployeeManagementCLI.Console.Test.MockModelsCreators
{
    internal class MessageCreator
    {
        public static Message? Null_model = null;
        public static Message Empty_model = new Message(ActionStatus.Error, null);
        public static Message Empty_text_model = new Message(ActionStatus.NotSuccess, string.Empty);
        public static Message Full_model = new Message(ActionStatus.Success, "testString");
    }
}
