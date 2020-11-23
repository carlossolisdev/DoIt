using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Services
{
    public class TransactionsServices
    {
        public async Task CreateTransaction(Transaction transaction)
        {
            using (var context = new DoItEntities())
            {
                context.Transactions.Add(transaction);
                await context.SaveChangesAsync();
            }
        }

        public Transaction GetTransactionById(int transactionId)
        {
            using (var context = new DoItEntities())
            {
                return context.Transactions.FirstOrDefault(x => x.TransactionId == transactionId);
            }
        }

        public IEnumerable<Transaction> GetTransactionsByCustomerId(int authorId)
        {
            using (var context = new DoItEntities())
            {
                return context.Transactions.Where(x => x.CustomerId == authorId).ToList();
            }
        }

        public IEnumerable<Transaction> GetTransactionsByProviderId(int authorId)
        {
            using (var context = new DoItEntities())
            {
                return context.Transactions.Where(x => x.ProviderId == authorId).ToList();
            }
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            using (var context = new DoItEntities())
            {
                var transactionToUpdate = context.Transactions.FirstOrDefault(x => x.TransactionId == transaction.TransactionId);
                transactionToUpdate = transaction;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTransaction(int id)
        {
            using (var context = new DoItEntities())
            {
                var transactionToDelete = context.Transactions.FirstOrDefault(x => x.TransactionId == id);
                context.Transactions.Remove(transactionToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}