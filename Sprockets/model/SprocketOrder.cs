using System;
using System.Collections.Generic;
using System.Linq;

namespace sprocket.model
{
    public class SprocketOrder
    {
        private List<Sprocket> items = new List<Sprocket>();
        
        public Address Address { get; set; }
        
        public string CustomerName { get; set; }
        
        public decimal TotalPrice { get { return Calc(); } }

        public SprocketOrder() { }
        public SprocketOrder(Address address, string custmerName, List<Sprocket> items) {
            Address = address;
            CustomerName = custmerName;
            this.items = items;
        }

        public void Add(Sprocket sprocket) {
            items.Add(sprocket);
        }

        public void Remove(Sprocket sprocket) {
            items.Remove(sprocket);
        }
        private decimal Calc()
        {
            return items.Select(s => s.Price).Aggregate(0m, (acc, price) => acc + price);
        }

        public override string ToString()
        {
            return
            $"{CustomerName}: {items.Count} item" + (items.Count == 1 ? "" : "s") + $", Total price: ${TotalPrice}\n" +
            "Ship to: " + (Address is null ? "Local Pickup" : Address.ToString()) + "\n\n" +
            String.Join("\n", items.Select(s => s.ToString()));
        }
    }
}