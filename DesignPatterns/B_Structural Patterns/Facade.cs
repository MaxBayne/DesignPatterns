using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.B_Structure_Patterns
{
    /// <summary>
    /// امر بيع
    /// </summary>
    public class FacadeSaleOrder
    {
        private Inventory _inventory;
        private InventoryOrder _inventoryOrder;
        

        public FacadeSaleOrder()
        {
            _inventory = new Inventory();
            _inventoryOrder = new InventoryOrder();
        }

        public void CreateOrder(ShoppingCart cart)
        {
            //Check if shopping cart have less than one item inside it


            //Check if item exist inside inventory or not


            //Create Inventory Order

            foreach (var item in cart.Items)
            {
                Console.WriteLine($"Sell ({item.ItemName}) with Quantity ({item.Quantity}) by price ({item.UnitPrice}) @ ({item.SubTotal}) ");
            }


        }
    }

    
    /// <summary>
    /// عنصر داخل كارت
    /// </summary>
    public class CartItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double SubTotal => Quantity * UnitPrice;
    }

    /// <summary>
    /// كارت تسوق
    /// </summary>
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public List<CartItem> Items { get; set; }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }


    }

    /// <summary>
    /// المخزون
    /// </summary>
    public class Inventory
    {
        public bool Check_Product_Available(int productId, int storeId)
        {
            return true;
        }
    }
    /// <summary>
    /// امر صرف من المخزن
    /// </summary>
    public class InventoryOrder
    {
        public void CreateOrder(ShoppingCart cart) 
        { 

        }
    }

    
}
