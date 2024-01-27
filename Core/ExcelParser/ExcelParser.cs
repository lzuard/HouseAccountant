using ClosedXML.Excel;

namespace Core.ExcelParser
{
    public class ExcelParser: IExcelParser
    {

        private string ValidateFile (string fileName) 
        {
            return "";
        }

        public Dictionary<string, List<string>> Parse(Stream fileStrem)
        {
            var data = new Dictionary<string, List<string>>();
            using var file = new XLWorkbook(fileStrem);
            var sheet = file.Worksheet(1);

            var header = sheet.FirstRowUsed().CellsUsed().ToList();

            foreach ( var row in sheet.RowsUsed().Skip(1) ) //Iterate rows
            {

                for (int i = 2; i<=header.Count; i++) //Iterate columns in row
                {
                    var key = header[i-1].Value.ToString();
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
