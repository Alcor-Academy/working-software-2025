using NSubstitute;
using StockPortfolioKata.test.Acceptance;

namespace StockPortfolioKata.test.Unit;

public class StockPortfolioAppShould
{
    private StockPortfolioApp stockPortfolioApp;
    private ICalendar calendar;
    private IPrinter printer;

    [SetUp]
    public void SetUp()
    {
        calendar = Substitute.For<ICalendar>();
        printer = Substitute.For<IPrinter>();
        var transactionRepository = new FakeRepository();
        stockPortfolioApp = new StockPortfolioApp(calendar, new PrinterService(printer),transactionRepository);
    }

    [Test]
    public void PrintEmptyReport()
    {
        stockPortfolioApp.Print();
        
        printer.Received(1).Print("date | share name | operation | quantity");
    }
    
    [Test]
    public void BuyOneAndPrintOneLine()
    {
        calendar.GetDate().Returns(new DateTime(2023, 2, 10));
        stockPortfolioApp.Buy(10, "Old School Waterfall Software LTD");
        
        stockPortfolioApp.Print();
        
        printer.Received(1).Print("date | share name | operation | quantity\n" +
                                      "10/02/2023 | Old School Waterfall Software LTD | BUY | 10");
    }
    
    [Test]
    public void SellOneAndPrintOneLine()
    {
        calendar.GetDate().Returns(new DateTime(2023, 2, 10));
        stockPortfolioApp.Sell(10, "Old School Waterfall Software LTD");
        
        stockPortfolioApp.Print();
        
        printer.Received(1).Print("date | share name | operation | quantity\n" +
                                  "10/02/2023 | Old School Waterfall Software LTD | SELL | 10");
    }
}