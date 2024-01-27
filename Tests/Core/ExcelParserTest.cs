using Core.ExcelParser;

namespace Tests.Core
{
    internal class ExcelParserTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Parse()
        {
            ExcelParser parser = new ExcelParser();
            var data = parser.Parse("E:\\Windows Files\\Downloads\\tink_jan.xlsx");
            foreach (var key in data.Keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
