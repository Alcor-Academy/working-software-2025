using StockPortfolioKata.Domain;

namespace StockPortfolioKata.test.Unit;

public interface IRepository
{
    void AddTransaction(Transaction transaction);
    List<Transaction> GetTransactions();
}