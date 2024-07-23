using EmployeeManagementCLI.Services;

namespace EmployeeManagementCLI.Tests.SevicesTests
{
    [TestClass]
    public class JsonServiceTest
    {
        #region Write models
        [TestMethod]
        public void Write_MockModel1()
        {
            var path = "Write_MockModel1.json";
            var jsonService = new JsonService(path);
            var model = new MockModel1();

            jsonService.WriteModel(model);
            string fileText = File.ReadAllText(path);
            File.Delete(path);

            Assert.IsTrue(fileText == "{}");
        }

        [TestMethod]
        public void Write_MockModel2()
        {
            var path = "Write_MockModel2.json";
            var jsonService = new JsonService(path);
            var model = new MockModel2()
            {
                IntField = 2,
                StringField = "test"
            };

            jsonService.WriteModel(model);
            var fileText = File.ReadAllText(path);
            File.Delete(path);

            Assert.IsTrue(fileText == "{\"IntField\":2,\"StringField\":\"test\"}");
        }

        [TestMethod]
        public void Write_MockModel3()
        {
            var path = "Write_MockModel3.json";
            var jsonService = new JsonService(path);

            var model2_1 = new MockModel2()
            {
                IntField = 1,
                StringField = "model1"
            };

            var model2_2 = new MockModel2()
            {
                IntField = 2,
                StringField = "model2"
            };

            var model2_3 = new MockModel2()
            {
                IntField = 3,
                StringField = "model3"
            };

            var model = new MockModel3()
            {
                IntField = 0,
                EnumField = MockEnum.First,
                MockModels = [model2_1, model2_2, model2_3]
            };

            jsonService.WriteModel(model);
            var fileText = File.ReadAllText(path);
            File.Delete(path);

            Assert.IsTrue(fileText == "{\"IntField\":0,\"EnumField\":1,\"MockModels\":[{\"IntField\":1,\"StringField\":\"model1\"},{\"IntField\":2,\"StringField\":\"model2\"},{\"IntField\":3,\"StringField\":\"model3\"}]}");
        }

        [TestMethod]
        public void Write_MockModel2_No_Directory()
        {
            var path = "NoDirectpry\\Write_MockModel2.json";
            var jsonService = new JsonService(path);
            var model = new MockModel2()
            {
                IntField = 2,
                StringField = "test"
            };

            jsonService.WriteModel(model);
            string fileText = File.ReadAllText(path);

            var dirPath = Path.GetDirectoryName(path);
            Directory.Delete(dirPath, true);

            Assert.IsTrue(fileText == "{\"IntField\":2,\"StringField\":\"test\"}");
        }
        #endregion

        #region Read models

        #endregion

        #region Mock models
        private class MockModel1 { }

        private class MockModel2
        {
            public int IntField { get; set; }
            public string StringField { get; set; } = string.Empty;
        }

        private class MockModel3
        {
            public int IntField { get; set; }
            public MockEnum EnumField { get; set; }
            public MockModel2[]? MockModels { get; set; }
        }

        private enum MockEnum
        {
            None,
            First,
            Second
        }
        #endregion
    }
}
