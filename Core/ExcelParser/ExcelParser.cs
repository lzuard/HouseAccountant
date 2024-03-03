using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Concurrent;

namespace Core.ExcelParser
{
    public class ExcelParser: IExcelParser
    {

        private string ValidateFile (string fileName) 
        {
            return "";
        }

        /// <summary>
        /// Parse files async
        /// </summary>
        /// <returns> Tuple: header, data</returns>
        public async Task<(List<string>,List<Dictionary<string, string>>)> ParseNewAsync(List<Stream> fileStreamList)
        {
            //List here is to make it possible .Add() in Parallel.ForEach()
            var data = new ConcurrentBag<List<Dictionary<string, string>>>();
            await Task.Run(() => Parallel.ForEach(fileStreamList, (stream) => { data.Add(ParseSingleFile(stream)); }));
            //Flatten bag
            var dataList = data.SelectMany(i => i).ToList();
            
            var header = dataList.SelectMany(dict => dict.Keys).Distinct().ToList();
            return (header, dataList);
        }

        /// <summary>
        /// Parse single file
        /// </summary>
        public List<Dictionary<string, string>> ParseSingleFile(Stream fileStream)
        {
            var data = new List<Dictionary<string, string>>();

            using var workbook = new XLWorkbook(fileStream);
            var sheet = workbook.Worksheet(1); //Using only first sheet for now

            //First row is the header
            var header = new List<string>();
            foreach (var cell in sheet.Row(1).Cells())
                header.Add(cell.Value.ToString());

            //Itterate every row
            for (var i = 2; i <= sheet.LastRowUsed().RowNumber(); i++)
            {
                var row = sheet.Row(i); // get all row
                var dict = new Dictionary<string, string>();
                //Itterate every column in a row
                for (int j = 1; j < header.Count; j++)
                    dict[header[j-1]] = row.Cell(j).Value.ToString();
                data.Add(dict);
            }
            return data;
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
