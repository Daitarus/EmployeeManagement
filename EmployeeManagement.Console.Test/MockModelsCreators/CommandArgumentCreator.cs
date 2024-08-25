using EmployeeManagement.Console.Commands.Models;

namespace EmployeeManagement.Console.Test.MockModelsCreators
{
    internal static class CommandArgumentCreator
    {
        public static CommandArgument Null_model = null;

        public static CommandArgument Unknown_model_with_null = new CommandArgument(ArgumentType.Unknown, null);
        public static CommandArgument Unknown_model_with_empty = new CommandArgument(ArgumentType.Unknown, string.Empty);
        public static CommandArgument Unknown_model_with_data = new CommandArgument(ArgumentType.Unknown, "testData");

        public static CommandArgument Id_model_with_null = new CommandArgument(ArgumentType.Id, null);
        public static CommandArgument Id_model_with_empty = new CommandArgument(ArgumentType.Id, string.Empty);
        public static CommandArgument Id_model_with_dataStr = new CommandArgument(ArgumentType.Id, "testData");
        public static CommandArgument Id_model_with_dataInt_zero = new CommandArgument(ArgumentType.Id, "0");
        public static CommandArgument Id_model_with_dataInt_positiv = new CommandArgument(ArgumentType.Id, "14");
        public static CommandArgument Id_model_with_dataInt_negativ = new CommandArgument(ArgumentType.Id, "-24");
        public static CommandArgument Id_model_with_dataFloat = new CommandArgument(ArgumentType.Id, "43.12");

        public static CommandArgument FirstName_model_with_null = new CommandArgument(ArgumentType.FirstName, null);
        public static CommandArgument FirstName_model_with_empty = new CommandArgument(ArgumentType.FirstName, string.Empty);
        public static CommandArgument FirstName_model_with_data = new CommandArgument(ArgumentType.FirstName, "testFirstName");

        public static CommandArgument LastName_model_with_null = new CommandArgument(ArgumentType.LastName, null);
        public static CommandArgument LastName_model_with_empty = new CommandArgument(ArgumentType.LastName, string.Empty);
        public static CommandArgument LastName_model_with_data = new CommandArgument(ArgumentType.LastName, "testLastName");

        public static CommandArgument SalaryPerHour_model_with_null = new CommandArgument(ArgumentType.SalaryPerHour, null);
        public static CommandArgument SalaryPerHour_model_with_empty = new CommandArgument(ArgumentType.SalaryPerHour, string.Empty);
        public static CommandArgument SalaryPerHour_model_with_data = new CommandArgument(ArgumentType.SalaryPerHour, "testData");
        public static CommandArgument SalaryPerHour_model_with_dataInt_zero = new CommandArgument(ArgumentType.SalaryPerHour, "0");
        public static CommandArgument SalaryPerHour_model_with_dataInt_positov = new CommandArgument(ArgumentType.SalaryPerHour, "15");
        public static CommandArgument SalaryPerHour_model_with_dataInr_negativ = new CommandArgument(ArgumentType.SalaryPerHour, "-252");
        public static CommandArgument SalaryPerHour_model_with_dataDecimal_postitv = new CommandArgument(ArgumentType.SalaryPerHour, "34.1241223");
        public static CommandArgument SalaryPerHour_model_with_dataDecimal_negativ = new CommandArgument(ArgumentType.SalaryPerHour, "-37.3422214");
    }
}
