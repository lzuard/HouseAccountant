using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataWorker
{
    public interface IDataWorker
    {
        public Task SaveDataAsync(IEnumerable<Dictionary<string, string>> data);
    }
}
