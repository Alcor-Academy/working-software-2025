using System.Runtime.InteropServices.JavaScript;
using NSubstitute;
using StockPortfolioKata.test.Unit;

namespace StockPortfolioKata.test.Acceptance
{
    public partial class StockPortfolioScenarios
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
        
        private void I_bought_shares(int quantity, string companyName, string date)
        {
            calendar.GetDate().Returns(ParseDate(date));
            stockPortfolioApp.Buy(quantity, companyName);
        }

        private void I_sold_shares(int quantity, string companyName, string date)
        {
            calendar.GetDate().Returns(ParseDate(date));
            stockPortfolioApp.Sell(quantity, companyName);
        }

        private static DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", null);
        }

        private void Print_portfolio()
        {
            stockPortfolioApp.Print();
        }

        private void Printed_portfolio_should_be(string expected)
        {
            printer.Received(1).Print(expected);
        }
    }
}