using ClosedXML.Excel;

namespace Core.ExcelParser
{
    public class ExcelParser
    {

        private string ValidateFile (string fileName) 
        {
            return "";
        }

        public Dictionary<string, List<string>> Parse(string fileName)
        {
            var data = new Dictionary<string, List<string>>();
            using var file = new XLWorkbook(fileName);
            var sheet = file.Worksheet(1);

            var header = sheet.FirstRowUsed();

            foreach ( var row in sheet.RowsUsed().Skip(1) ) //Iterate rows
            {
                for (int i = 2; i<=header.CellCount(); i++) //Iterate columns in row
                {
                    var key = header.Cell(i).Value.ToString();
                    var value = row.Cell(i).Value.ToString();

                    if (!data.ContainsKey(key))
                        data[key] = new List<string>();
                    data[key].Add(value);
                }
            }

            return data;
        }
    }
}
