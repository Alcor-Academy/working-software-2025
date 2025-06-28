using StockPortfolioKata.Domain;
using StockPortfolioKata.test.Unit;

namespace StockPortfolioKata.test.Acceptance;

internal class StockPortfolioApp
{
    private readonly ICalendar _calendar;
    private readonly PrinterService _printerService;
    private readonly IRepository _transactionRepository;

    public StockPortfolioApp(ICalendar calendar, PrinterService printerService, IRepository transactionRepository)
    {
        _calendar = calendar;
        _printerService = printerService;
        _transactionRepository = transactionRepository;
    }

    public void Buy(int quantity, string companyName)
    {
        var date = _calendar.GetDate();
        _transactionRepository.AddTransaction(new Transaction(quantity, companyName,date,TransactionTypeEnum.BUY));
    }

    public void Sell(int quantity, string companyName)
    {
        var date = _calendar.GetDate();
        _transactionRepository.AddTransaction(new Transaction(quantity, companyName,date,TransactionTypeEnum.SELL));
    }

    public void Print()
    {
        var transactions = _transactionRepository.GetTransactions();
        _printerService.Print(transactions);
    }
}