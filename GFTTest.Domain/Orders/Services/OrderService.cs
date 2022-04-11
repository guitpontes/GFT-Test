using GFTTest.Domain.Orders.Entities;
using GFTTest.Domain.Orders.Enums;
using GFTTest.Domain.Orders.Interfaces;
using GFTTest.Domain.Orders.Services.Interfaces;

namespace GFTTest.Domain.Orders.Services
{
    public class OrderService : IOrderService
    {
        public Order TakeOrder(TimeEnum time, Dictionary<int, int> orderList)
        {
            Order order;
            if (time.Equals(TimeEnum.Morning))
                order = CheckMorningOder(orderList);
            else
                order = CheckNightOder(orderList);

            return order;
        }


        private Order CheckMorningOder(Dictionary<int, int> orderList)
        {
            string entree = null;
            string side = null;
            string drink = null;
            string dessert = null;

            if (orderList != null)
            {
                var errorOrder = orderList.Where(o => (o.Key != 3 && o.Value > 1) || o.Key > 3).FirstOrDefault();

                if (errorOrder.Key != 0)
                {
                    if (errorOrder.Key == 1)
                    {
                        entree = "eggs, error";
                    }
                    if (errorOrder.Key == 2)
                    {
                        entree = "eggs";
                        side = " toast, error";
                    }
                    if (errorOrder.Key > 3)
                    {
                        int coffeeQty = orderList.Where(x => x.Key == 3).FirstOrDefault().Value;

                        entree = "eggs";
                        side = " toast";
                        drink = coffeeQty > 1 ? $" coffee(x{coffeeQty})" : " coffee";
                        dessert = " error";
                    }
                }
                else
                {
                    int coffeeQty = orderList.Where(x => x.Key == 3).FirstOrDefault().Value;

                    entree = orderList.Any(x => x.Key == 1) ? "eggs" : "";
                    side = orderList.Any(x => x.Key == 2) ? " toast " : "";
                    drink = orderList.Any(x => x.Key == 3) ? coffeeQty > 1 ? $" coffee(x{coffeeQty})" : " coffee" : "";
                    dessert = String.Empty;
                }
            }
            return new Order(entree, side, drink, dessert);
        }

        private Order CheckNightOder(Dictionary<int, int> orderList)
        {
            string entree = null;
            string side = null;
            string drink = null;
            string dessert = null;

            if (orderList != null)
            {
                var errorOrder = orderList.Where(o => (o.Key != 2 && o.Value > 1) || o.Key > 4).FirstOrDefault();

                if (errorOrder.Key != 0)
                {
                    if (errorOrder.Key == 1)
                    {
                        entree = "steak, error";
                    }
                    if (errorOrder.Key == 3)
                    {
                        int potatoQty = orderList.Where(x => x.Key == 2).FirstOrDefault().Value;

                        entree = "steak";
                        side = potatoQty > 1 ? $" potato(x{potatoQty})" : " potato";
                        drink = " wine, error";
                    }
                    if (errorOrder.Key == 4)
                    {
                        int potatoQty = orderList.Where(x => x.Key == 2).FirstOrDefault().Value;

                        entree = "steak";
                        side = potatoQty > 1 ? $" potato(x{potatoQty})" : " potato";
                        drink = " wine";
                        dessert = " error";
                    }
                    if (errorOrder.Key > 4)
                    {
                        int potatoQty = orderList.Where(x => x.Key == 2).FirstOrDefault().Value;

                        entree = " steak";
                        side = potatoQty > 1 ? $" potato(x{potatoQty})" : " potato";
                        drink = " wine";
                        dessert = " cake, error";
                    }
                }
                else
                {
                    int potatoQty = orderList.Where(x => x.Key == 2).FirstOrDefault().Value;

                    entree = orderList.Any(x => x.Key == 1) ? " steak" : null;
                    side = orderList.Any(x => x.Key == 2) ? potatoQty > 1 ? $" potato(x{potatoQty})" : " potato" : null;
                    drink = orderList.Any(x => x.Key == 3) ? " wine" : null;
                    dessert = orderList.Any(x => x.Key == 4) ? " cake" : null;
                }
            }
            return new Order(entree, side, drink, dessert);
        }
    }
}
