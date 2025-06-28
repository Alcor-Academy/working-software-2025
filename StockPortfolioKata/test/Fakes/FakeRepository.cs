using StockPortfolioKata.Domain;

namespace StockPortfolioKata.test.Unit;

public class FakeRepository : IRepository
{
    public List<Transaction> Transactions { get; } = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
    }

    public List<Transaction> GetTransactions()
    {
        return Transactions;
    }
    
}