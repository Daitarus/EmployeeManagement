using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Test.MockModelsCreators
{
    internal class CommandCreator
    {
        public static Command Null_model = null;

        public static Command Unknown_command_null_args_model = new Command(CommandType.Unknown, null);
        public static Command Unknown_command_empty_args_model = new Command(CommandType.Unknown, []);

        public static Command Unknown_one_args_model = new Command(CommandType.Unknown, [CommandArgumentCreator.Unknown_model_with_data]);
        public static Command Unknown_two_args_model = new Command(CommandType.Unknown, [CommandArgumentCreator.Unknown_model_with_data, CommandArgumentCreator.Unknown_model_with_data]);

        public static Command Unknown_command_valid_args_model = new Command(CommandType.Unknown, [CommandArgumentCreator.Id_model_with_dataInt_positiv]);

        public static Command Add_command_empty_args_model = new Command(CommandType.Add, []);
        public static Command Delete_command_unknown_args_model = new Command(CommandType.Delete, [CommandArgumentCreator.Unknown_model_with_data]);

        public static Command Get_command_only_id_args_model = new Command(CommandType.Get, [CommandArgumentCreator.Id_model_with_dataInt_positiv, CommandArgumentCreator.Id_model_with_dataInt_positiv]);
        public static Command Delete_command_more_args_model = new Command(CommandType.Delete, [CommandArgumentCreator.Id_model_with_dataInt_positiv, CommandArgumentCreator.FirstName_model_with_data]);

        public static Command Add_command_change_order_args_mode = new Command(CommandType.Add, [CommandArgumentCreator.FirstName_model_with_data, CommandArgumentCreator.SalaryPerHour_model_with_dataDecimal_negativ, CommandArgumentCreator.Id_model_with_dataInt_positiv, CommandArgumentCreator.LastName_model_with_data]);

        public static Command Add_command_valid_args_model = new Command(CommandType.Add, [CommandArgumentCreator.FirstName_model_with_data, CommandArgumentCreator.LastName_model_with_data, CommandArgumentCreator.SalaryPerHour_model_with_dataDecimal_postitv]);
        public static Command Delete_command_valid_args_model = new Command(CommandType.Delete, [CommandArgumentCreator.Id_model_with_dataInt_positiv]);
        public static Command Get_command_valid_args_model = new Command(CommandType.Get, [CommandArgumentCreator.Id_model_with_dataInt_positiv]);
        public static Command GetAll_command_no_args_model = new Command(CommandType.GetAll, []);
        public static Command Update_command_valid_args_model = new Command(CommandType.Update, [CommandArgumentCreator.Id_model_with_dataInt_positiv, CommandArgumentCreator.FirstName_model_with_data, CommandArgumentCreator.SalaryPerHour_model_with_dataDecimal_postitv]);
    }
}
