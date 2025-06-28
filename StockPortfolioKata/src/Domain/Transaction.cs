namespace StockPortfolioKata.Domain;

public class Transaction
{
    private readonly int Quantity;
    private readonly string CompanyName;
    private readonly DateTime Date;
    private readonly TransactionTypeEnum TransactionType;

    public Transaction(int quantity, string companyName, DateTime date, TransactionTypeEnum transactionType)
    {
        Quantity = quantity;
        CompanyName = companyName;
        Date = date;
        TransactionType = transactionType;
    }

    public override string ToString()
    {
        return $"{Date:dd/MM/yyyy} | {CompanyName} | {TransactionType} | {Quantity}";
    }
}

public enum TransactionTypeEnum
{
    BUY,
    SELL
}