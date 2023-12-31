namespace DesignPatterns.C_Behavioral_Patterns;

/*
 * Strategy Pattern
 * ----------------
 * used to select one function alogrithm from multi functions depend on some input parameters
 */

#region Car Strategy


public interface IStrategy
{
    void disassemble();
}

public class ToyotaStrategy : IStrategy
{
    public void disassemble()
    {
        Console.WriteLine("Disassimle Toyota Algorithem");
    }
}

public class BmwStrategy : IStrategy
{
    public void disassemble()
    {
        Console.WriteLine("Disassimle Bmw Algorithem");
    }
}

public class Mechanic
{
    public void DisassembleCar(IStrategy strategy)
    {
        strategy.disassemble();
    }
}

#endregion

#region Discount Strategy

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal totalInvoice);
}

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalInvoice)
    {
        return 0;
    }
}

public class SilverDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalInvoice)
    {
        return totalInvoice >= 10000 ? totalInvoice * 2 / 100 : 0;

    }
}

public class GoldDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalInvoice)
    {
        return totalInvoice >= 10000 ? totalInvoice * 5 / 100 : 0;

    }
}

public class DiamondDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal totalInvoice)
    {
        return totalInvoice >= 10000 ? totalInvoice * 10 / 100 : 0;

    }
}

public enum CustomerCategoryEnum
{
    Simple,
    Silver,
    Gold,
    Diamond
}

public class Invoice
{
    public DateTime InvoiceDate { get;private set; }
    public string CustomerName { get;private set; }
    public CustomerCategoryEnum CustomerCategory { get;private set; }
    public decimal TotalPrice { get;private set; }
    public decimal DiscountValue { get;private set; }
    public decimal NetPrice => TotalPrice - DiscountValue;

    private IDiscountStrategy _discountStrategy;

    public Invoice(string customerName,CustomerCategoryEnum customerCategory,decimal totalPrice)
    {
        InvoiceDate = DateTime.Now;
        CustomerName = customerName;
        CustomerCategory = customerCategory;
        TotalPrice = totalPrice;

        switch (customerCategory)
        {
            case CustomerCategoryEnum.Simple:
                _discountStrategy = new NoDiscountStrategy();
                break;
            case CustomerCategoryEnum.Silver:
                _discountStrategy = new SilverDiscountStrategy();
                break;
            case CustomerCategoryEnum.Gold:
                _discountStrategy = new GoldDiscountStrategy();
                break;
            case CustomerCategoryEnum.Diamond:
                _discountStrategy = new DiamondDiscountStrategy();
                break;
            default:
                _discountStrategy = new NoDiscountStrategy();
                break;
        }

        DiscountValue = _discountStrategy.CalculateDiscount(TotalPrice);

    }


    public void Print_Invoice_Info()
    {
        Console.WriteLine($"Created Invoice For Customer ({CustomerName}) with Category ({CustomerCategory}) with TotalPrice = {TotalPrice},Discount = {DiscountValue} , NetPrice= {NetPrice} ");
    }

}

#endregion