namespace EmployeeManagementCLI.Console.Test.MockModelsCreators
{
    internal class InputArgsCreator
    {
        public static string[] Null_model = null;
        public static string[] Empty_model = [];

        public static string[] Unknown_model = ["testData"];
        public static string[] Unknown_one_args_model = ["testData", "testData"];
        public static string[] Unknown_two_args_model = ["testData", "testData", "testData"];

        public static string[] Unknown_command_valid_args_model = ["testData", "Id:14"];

        public static string[] Add_command_empty_args_model = ["-add"];
        public static string[] Delete_command_unknown_args_model = ["-delete", "testData"];

        public static string[] Get_command_only_id_args_model = ["-get", "Id:14", "Id:14"];
        public static string[] Delete_command_more_args_model = ["-delete", "Id:14", "FirstName:testFirstName"];

        public static string[] Add_command_change_order_args_model = ["-add", "FirstName:testFirstName", "Salary:-37.3422214", "Id:14", "LastName:testLastName"];

        public static string[] Add_command_valid_args_model = ["-add", "FirstName:testFirstName", "LastName:testLastName", "Salary:34.1241223"];
        public static string[] Delete_command_valid_args_model = ["-delete", "Id:14"];
        public static string[] Get_command_valid_args_model = ["-get", "Id:14"];
        public static string[] GetAll_command_no_args_model = ["-getall"];
        public static string[] Update_command_valid_args_model = ["-update", "Id:14", "FirstName:testFirstName", "Salary:34.1241223"];

        public static string[] Get_command_many_separation_args_model = ["-get", "Id:14:15:153"];
    }
}
