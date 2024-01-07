using DesignPatterns.C_Behavioral_Patterns.StatePattern;
using System.Net;

namespace DesignPatterns.C_Behavioral_Patterns
{
    /*
     * Command Pattern
     * ---------------
     * - Command is the wrapper for some thing , we can wrap it inside command and can store command inside list or queue and execute it later or with 
     * some order etc ...
     * - we use CommandInvoker to store or create list of command and to execute it all
     */

    namespace OrderCommand
    {
        public interface ICommand
        {
            Task ExecuteAsync();
        }

        /// <summary>
        /// We Add Order Line inside Order
        /// </summary>
        public class AddOrderLineCommand : ICommand
        {
            private readonly Order _order;
            private readonly int _productId;
            private readonly string _productName;
            private readonly double _unitPrice;
            private readonly double _quantity;

            public AddOrderLineCommand(Order order,int productId,string productName,double unitPrice,double quantity)
            {
                _order = order;
                _productId = productId;
                _productName = productName;
                _unitPrice = unitPrice;
                _quantity = quantity;
            }

            public async Task ExecuteAsync()
            {
                await Task.Run(() =>
                {
                    _order.AddOrderLine(_productId, _productName, _quantity, _unitPrice);
                });
            }

        }

        /// <summary>
        /// set customer name inside order
        /// </summary>
        public class SetCustomerCommand:ICommand
        {
            private readonly Order _order;
            private readonly string _customerName;

            public SetCustomerCommand(Order order,string customerName)
            {
                _order = order;
                _customerName = customerName;
            }

            public async Task ExecuteAsync()
            {
                await Task.Run(() =>
                {
                    _order.SetCustomer(_customerName);
                });
            }
        }

        /// <summary>
        /// Print Order Line info into Console
        /// </summary>
        public class PrintOrderLineCommand:ICommand
        {
            private readonly int _productId;
            private readonly string _productName;
            private readonly double _unitPrice;
            private readonly double _quantity;

            public PrintOrderLineCommand(int productId, string productName, double unitPrice, double quantity)
            {
                _productId = productId;
                _productName = productName;
                _unitPrice = unitPrice;
                _quantity = quantity;
            }

            public async Task ExecuteAsync()
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("=============== (Order Line) ===================");
                    Console.WriteLine($"Id={_productId},Product={_productName},Quantity={_quantity},UnitPrice={_unitPrice}");
                    Console.WriteLine("==========================================");
                });
            }
        }

        public class CommandsInvokers
        {
            private List<ICommand> _commands = new();

            public void AddCommand(ICommand command)
            {
                _commands.Add(command);
            }

            public void RemoveCommand(ICommand command)
            {
                _commands.Remove(command);
            }

            public void ClearCommands()
            {
                _commands.Clear();
            }



            public async Task InvokeCommandsAsync()
            {
                foreach (var command in _commands)
                {
                    await command.ExecuteAsync();
                }

                ClearCommands();
            }

            public void InvokeCommands()
            {
                foreach (var command in _commands)
                {
                    command.ExecuteAsync();
                }

                ClearCommands();
            }
        }

    }



}