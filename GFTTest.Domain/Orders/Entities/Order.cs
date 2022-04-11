using GFTTest.Domain.Orders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Domain.Orders.Entities
{
    public class Order
    {
        public string? Entree { get; private set; }
        public string? Side { get; private set; }
        public string? Drink { get; private set; }
        public string? Dessert { get; private set; }

        protected Order() { }

        public Order(string entree, string side, string drink, string dessert)
        {
            this.Entree = entree;
            this.Side = side;
            this.Drink = drink;
            this.Dessert = dessert;
        }

        public override string ToString()
        {
            return String.Join(",", Entree,Side,Drink, Dessert).TrimEnd(',');
        }

    }
}
