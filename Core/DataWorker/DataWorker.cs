using Data.Models;
using Data.Repositories.Base;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataWorker
{
    public class DataWorker : IDataWorker
    {
        private IDbRepository<Transaction> _transactions;

        public DataWorker(IDbRepository<Transaction> transacrions) {
            _transactions = transacrions;
        }

        public async Task SaveDataAsync(IEnumerable<Dictionary<string, string>> data)
        {
            var transactionsBag = new ConcurrentBag<Transaction>();
            Parallel.ForEach(data, item => transactionsBag.Add(ExtractTransaction(item)));

            throw new NotImplementedException("No database conection yet");
            //_transactions.AddRange(transactionsBag);
        }

        private Transaction ExtractTransaction(Dictionary<string, string> data) => new Transaction
        {
            TransactionDateTime = DateTime.Now,
            Currency = "RUB",
            Amount = 100,
            User = new User(),
            Card = new Card(),
            Destination = new Destination()
        };
    }
}
