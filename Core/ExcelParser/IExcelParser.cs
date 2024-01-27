
namespace Core.ExcelParser
{
    public interface IExcelParser
    {
        public Dictionary<string, List<string>> Parse(Stream fileStrem);
    }
}
