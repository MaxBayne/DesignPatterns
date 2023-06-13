namespace DesignPatterns.C_Behavioral_Patterns;

public interface ICart
{
    void CheckOut();
}

public abstract class Cart : ICart
{
    public void CheckOut()
    {
        ValidateItems();
        DoPayment();
        SendInvoice();
    }

    private void ValidateItems()
    {
        Console.WriteLine("Validate Items");
    }

    private void DoPayment()
    {
        Console.WriteLine("Make Payments");
    }

    protected abstract void SendInvoice();
}

public class CartByEmail:Cart
{
    protected override void SendInvoice()
    {
        Console.WriteLine("Send Invoice By Email");
    }
}

public class CartBySms:Cart
{
    protected override void SendInvoice()
    {
        Console.WriteLine("Send Invoice By Sms");
    }
}