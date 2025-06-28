using StockPortfolioKata.Domain;

namespace StockPortfolioKata.test.Acceptance;

public class PrinterService
{
    private const string Header = "date | share name | operation | quantity";
    private readonly IPrinter _printer;

    public PrinterService(IPrinter printer)
    {
        _printer = printer;
    }

    public void Print(List<Transaction> transactions)
    {
        var statement = Header;
        foreach (var transaction in transactions)
        {
            statement += "\n" + transaction.ToString();
        }
        _printer.Print(statement);
    }
}