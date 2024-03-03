
namespace Core.ExcelParser
{
    public interface IExcelParser
    {
        public Dictionary<string, List<string>> Parse(Stream fileStrem);

        public Task<(List<string>, List<Dictionary<string, string>>)> ParseNewAsync(List<Stream> fileStreamList);
    }
}
