using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.A_Creational_Patterns
{

    /*
     * Factory Method Pattern
     * ----------------------
     * -  this pattern used when we have some classes with same domain or family but we will give client ability to extend and ad more classes to that
     *  family , so we dont know all classes of family so client will be inherit from abstract class that implement factory method
     *  
     *  Exmaple:
     *  if i need to make implementation for payment processor like paypal and visa and i need to give the client ability to extend my logic 
     *  and create his logic with more paymennt methods so i will be use factory method , just create abstract class for my basic implementation
     *  and give client ability to implement that abstract class with his own implementation like vodaphone cash and so on
     */

    #region Abstraction Layer

    public sealed class Payment
    {
        public Payment()
        {
            TransDate = DateTime.Now;
            TransId = Guid.NewGuid();
        }

        public Guid TransId { get; private set; }
        public DateTime TransDate { get; private set; }
        public int CustomerId { get;private set; }


        public double Amount { get;private set; }
        public double Fees { get; private set; }
        public double Total => Amount + Fees;
        

        public void SetAmount(double amount)
        {
            Amount = amount;
        }
        public void SetCustomerId(int customerId)
        {
            CustomerId = customerId;
        }
        public void SetFees(double fees)
        {
            Fees = fees;
        }
        
    }

    public interface IPaymentMethod
    {
        Payment Charge(int cusomterId,double amount);
    }

    public abstract class PaymentProcessor
    {
        public Payment ProcessPayment(int cusomterId,double amount)
        {
            //Get the Payment Method that Client implement inside payment processor
            var paymentMethod = CreatePaymentMethod();

            //Call the implemented method that client make it
            var payment = paymentMethod.Charge(cusomterId, amount);

            LogPayment(payment);

            return payment;
        }

        //This is Factory Method
        protected abstract IPaymentMethod CreatePaymentMethod();

        protected abstract void LogPayment(Payment payment);
    }

    #endregion

    #region Implementation Layer

    #region Visa Implementation
    
    public class VisaPaymentMethod : IPaymentMethod
    {
        public Payment Charge(int cusomterId, double amount)
        {
            var payment = new Payment();

            payment.SetCustomerId(cusomterId);
            payment.SetAmount(amount);
            payment.SetFees(amount*0.05);

            return payment;
        }
    }

    public class VisaPaymentProcessor : PaymentProcessor
    {
        //This is Factory Method
        protected override IPaymentMethod CreatePaymentMethod()
        {
            return new VisaPaymentMethod();
        }

        protected override void LogPayment(Payment payment)
        {
            Console.WriteLine($"Customer #{payment.CustomerId} Send Amount:{payment.Amount} with Fees {payment.Fees} and Charged {payment.Total} VIA Visa Payment Method");
        }
    }

    #endregion

    #region Master Implementation

    public class MasterPaymentMethod : IPaymentMethod
    {
        public Payment Charge(int cusomterId, double amount)
        {
            var payment = new Payment();

            payment.SetCustomerId(cusomterId);
            payment.SetAmount(amount);
            payment.SetFees(amount * 0.05);

            return payment;
        }

      
    }

    public class MasterPaymentProcessor : PaymentProcessor
    {
        protected override IPaymentMethod CreatePaymentMethod()
        {
            return new MasterPaymentMethod();
        }

        protected override void LogPayment(Payment payment)
        {
            Console.WriteLine($"Customer #{payment.CustomerId} Send Amount:{payment.Amount} with Fees {payment.Fees} and Charged {payment.Total} VIA Master Payment Method");
        }
    }

    #endregion

    #region Paypal Implementation

    public class PaypalPaymentMethod : IPaymentMethod
    {
        public Payment Charge(int cusomterId, double amount)
        {
            var payment = new Payment();

            payment.SetCustomerId(cusomterId);
            payment.SetAmount(amount);
            payment.SetFees(amount * 0.02);

            return payment;
        }
    }

    public class PaypalPaymentProcessor : PaymentProcessor
    {
        protected override IPaymentMethod CreatePaymentMethod()
        {
            return new PaypalPaymentMethod();
        }

        protected override void LogPayment(Payment payment)
        {
            Console.WriteLine($"Customer #{payment.CustomerId} Send Amount:{payment.Amount} with Fees {payment.Fees} and Charged {payment.Total} VIA Paypal Payment Method");
        }
    }

    #endregion

    #endregion
}
