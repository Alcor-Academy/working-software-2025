namespace StockPortfolioKata.test.Acceptance
{
    [TestFixture]
    public partial class StockPortfolioScenarios
    {
        [Test]
        public void PrintPorfolio() 
        {
            I_bought_shares(1000, "Old School Waterfall Software LTD", "14/02/1990");
            I_bought_shares(800, "Crafter Masters Limited", "03/08/2006");
            I_sold_shares(500, "Old School Waterfall Software LTD", "11/12/2010");
            I_bought_shares(700, "XP Practitioners Incorporated", "09/06/2016");
            I_sold_shares(300, "Old School Waterfall Software LTD", "11/02/2020");

            Print_portfolio();

            string expected = "date | share name | operation | quantity\n" +
                              "14/02/1990 | Old School Waterfall Software LTD | BUY | 1000\n" +
                              "03/08/2006 | Crafter Masters Limited | BUY | 800\n" +
                              "11/12/2010 | Old School Waterfall Software LTD | SELL | 500\n" +
                              "09/06/2016 | XP Practitioners Incorporated | BUY | 700\n" +
                              "11/02/2020 | Old School Waterfall Software LTD | SELL | 300";
            Printed_portfolio_should_be(expected);
        }
    }
}