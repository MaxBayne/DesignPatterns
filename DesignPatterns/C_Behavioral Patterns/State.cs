using System.ComponentModel.Design;

namespace DesignPatterns.C_Behavioral_Patterns
{
    namespace StatePattern
    {
        #region Vehicle State


        public enum VehicleState
        {
            Started,
            Running,
            Stopped
        }

        public class Vehicle
        {
            public VehicleState State { get; private set; }

            public Vehicle()
            {
                StopVehicle();
            }

            public void StartVehicle()
            {
                if (State == VehicleState.Stopped)
                {
                    State = VehicleState.Started;

                    Console.WriteLine($"Vehicle State Changed From Stopped To Started");
                }
            }
            public void StopVehicle()
            {
                if (State == VehicleState.Started)
                {
                    State = VehicleState.Stopped;

                    Console.WriteLine($"Vehicle State Changed From Started To Stopped");
                }
                else if (State == VehicleState.Running)
                {
                    Console.WriteLine($"Vehicle State Changed From Running To Stopped");
                }
                else
                {
                    State = VehicleState.Stopped;

                    Console.WriteLine($"Vehicle State Changed To Stopped");
                }
            }
            public void AccelerateVehicle()
            {
                if (State == VehicleState.Started)
                {
                    State = VehicleState.Running;

                    Console.WriteLine($"Vehicle State Changed From Started To Running");
                }
            }
        }

        #endregion

        #region Order State

        public interface IOrderState
        {
            
        }

        public class OrderDraftedState : IOrderState
        {
            public OrderDraftedState(Order order) 
            {
                Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
            }

            public override string ToString() => "DraftState";
        }
        public class OrderConfirmedState : IOrderState
        {
            public OrderConfirmedState(Order order)
            {
                if(order.OrderState is OrderDraftedState)
                {
                    Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
                }
                else
                {
                    throw new Exception($"Cant Change Order State From ({order.OrderState}) to ({this})");
                }
            }

            public override string ToString() => "ConfirmState";
        }
        public class OrderCanceledState : IOrderState
        {
            public OrderCanceledState(Order order)
            {
                if (order.OrderState is OrderConfirmedState or OrderDraftedState)
                {
                    Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
                }
                else
                {
                    throw new Exception($"Cant Change Order State From ({order.OrderState}) to ({this})");
                }
                
            }

            public override string ToString() => "CancelState";

        }
        public class OrderProcessedState : IOrderState
        {
            public OrderProcessedState(Order order)
            {
                if (order.OrderState is OrderConfirmedState)
                {
                    Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
                }
                else
                {
                    throw new Exception($"Cant Change Order State From ({order.OrderState}) to ({this})");
                }
            }

            public override string ToString() => "ProcessState";

        }
        public class OrderShippedState : IOrderState
        {
            public OrderShippedState(Order order)
            {
                if (order.OrderState is OrderProcessedState)
                {
                    Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
                }
                else
                {
                    throw new Exception($"Cant Change Order State From ({order.OrderState}) to ({this})");
                }
            }

            public override string ToString() => "ShippedState";
        }
        public class OrderDeliveredState : IOrderState
        {
            public OrderDeliveredState(Order order)
            {
                if (order.OrderState is OrderShippedState)
                {
                    Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
                }
                else
                {
                    throw new Exception($"Cant Change Order State From ({order.OrderState}) to ({this})");
                }
            }

            public override string ToString() => "DeliveredState";
        }
        public class OrderReturnedState : IOrderState
        {
            public OrderReturnedState(Order order)
            {
                if (order.OrderState is OrderDeliveredState)
                {
                    Console.WriteLine($"Order State Changed From ({order.OrderState}) To ({this})");
                }
                else
                {
                    throw new Exception($"Cant Change Order State From ({order.OrderState}) to ({this})");
                }
            }

            public override string ToString() => "ReturnedState";

        }



        public class Order 
        {
            public DateTime OrderDate { get; private set; }
            public string Customer { get; private set; }
            public List<OrderLine> OrderLines { get;private set; }
            public IOrderState OrderState { get; internal set; }

            public Order()
            {
                OrderDate = DateTime.Now;
                OrderLines = new List<OrderLine>();
                Customer = string.Empty;
                OrderState = new OrderDraftedState(this);
            }

            public void SetCustomer(string customer)
            {
                Customer = customer;
            }

            public void AddOrderLine(int id,string name,double quantity,double unitPrice)
            {
                OrderLines.Add(new OrderLine(id,name,quantity,unitPrice));
            }

            public void DraftOrder()
            {
                try
                {
                    OrderState = new OrderDraftedState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }
            public void ConfirmOrder()
            {
                
                try
                {
                    OrderState = new OrderConfirmedState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            public void CancelOrder()
            {
                
                try
                {
                    OrderState = new OrderCanceledState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            public void ProcessOrder()
            {
                
                try
                {
                    OrderState = new OrderProcessedState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            public void ShippedOrder()
            {
                
                try
                {
                    OrderState = new OrderShippedState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            public void DeliverOrder()
            {
                
                try
                {
                    OrderState = new OrderDeliveredState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            public void ReturnOrder()
            {
                try
                {
                    OrderState = new OrderReturnedState(this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                
            }
            
        }
        public class OrderLine
        {
            public int Id { get;private set; }
            public string Name { get; private set; }
            public double Quantity { get; private set; }
            public double UnitPrice { get; private set; }
            public double SubTotal => Quantity * UnitPrice;

            public OrderLine(int id,string name,double quantity,double unitPrice)
            {
                Id = id;
                Name = name;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }
        }



        #endregion
    }
}