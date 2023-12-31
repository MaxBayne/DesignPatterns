namespace DesignPatterns.C_Behavioral_Patterns;

/*
 * Template Pattern:
 * -----------------
 * 
 * if u have function/method and will be varied depend on some logic or cases and u need to let the logic for client so will be abstract method
 *  
 */


public abstract class ShoppingCartBase
{
    private string _customerName;
    private CustomerCategoryEnum _customerCategory;
    private decimal _totalPrice;
    private decimal _totalDiscount;
    private decimal _taxAmount;
    private decimal _netPrice;

    public ShoppingCartBase(string customerName,CustomerCategoryEnum customerCateogry)
    {
        _customerName = customerName;
        _customerCategory = customerCateogry;
    }

    public void Checkout(decimal totalPrice) 
    {
        _totalPrice = totalPrice;

        //Create Invoice
        var invoice = new Invoice(_customerName, _customerCategory, _totalPrice);

        //Apply Tax
        ApplyTax(invoice);

        //Apply Discount
        ApplyDiscount(invoice, _customerCategory);

        //Process Payment Method
        ProcessPaymentMethod(invoice);
    }

    private void ApplyTax(Invoice invoice) => invoice.TaxPercent = 0.15M;


    //Template Method
    public abstract void ApplyDiscount(Invoice invoice,CustomerCategoryEnum customerCategory);

    private void ProcessPaymentMethod(Invoice invoice) 
    {
        Console.WriteLine($"{GetType().Name} => Process Invoice For Customer ({invoice.CustomerName}) with Category ({invoice.CustomerCategory}) with TotalPrice={invoice.TotalPrice},TaxAmount={invoice.TaxAmount},DiscountAmount={invoice.DiscountAmount},NetPrice={invoice.NetPrice}");
    }

}

public class OnlineShoppingCart : ShoppingCartBase
{
    public OnlineShoppingCart(string customerName, CustomerCategoryEnum customerCateogry) : base(customerName, customerCateogry)
    {
    }

    public override void ApplyDiscount(Invoice invoice, CustomerCategoryEnum customerCategory)
    {
        switch (customerCategory)
        {
            case CustomerCategoryEnum.Simple:
                invoice.SetDiscount(0);
                break;
            case CustomerCategoryEnum.Silver:
                invoice.SetDiscount(20);
                break;
            case CustomerCategoryEnum.Gold:
                invoice.SetDiscount(30);
                break;
            case CustomerCategoryEnum.Diamond:
                invoice.SetDiscount(50);
                break;
            default:
                break;
        }
    }
}

public class InStoreShoppingCart : ShoppingCartBase
{
    public InStoreShoppingCart(string customerName, CustomerCategoryEnum customerCateogry) : base(customerName, customerCateogry)
    {
    }

    public override void ApplyDiscount(Invoice invoice, CustomerCategoryEnum customerCategory)
    {
        invoice.SetDiscount(0);
    }
}