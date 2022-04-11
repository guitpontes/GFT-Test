using GFTTest.Application.OrderApplication.Services;
using GFTTest.Domain.Orders.Interfaces;
using GFTTest.Domain.Orders.Services.Interfaces;
using Xunit;
using NSubstitute;
using System.Collections.Generic;
using GFTTest.Domain.Orders.Entities;
using FizzWare.NBuilder;
using System.Linq;
using GFTTest.DataTransfer.Requests;
using System;
using GFTTest.Domain.Orders.Enums;

namespace GFTTest.Tests
{
    public class ApplicationTests
    {
        private readonly OrderAppService sut;
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;

        public ApplicationTests()
        {
            _orderService = Substitute.For<IOrderService>();
            _orderRepository = Substitute.For<IOrderRepository>();

            sut = new OrderAppService(_orderService, _orderRepository);
        }

        public class GetOrderMethod : ApplicationTests
        {
            [Fact]
            public void When_ListIsFilled_Expect_PopulatedList()
            {
                List<Order> testOrders = Builder<Order>.CreateListOfSize(10).Build().ToList();
                _orderRepository.FindAll().Returns(testOrders);
            
                var testReturn = sut.GetAllOrders();

                Assert.True(testReturn != null);
                Assert.True(testReturn.Count == 10);
            }
        }

        public class TakeOrdersMethod : ApplicationTests
        {
            [Theory]
            [InlineData("day")]
            [InlineData("evening")]
            public void When_TimeIsNotRight_Expect_Exception(string time)
            {
                var orderList = new List<int> { 1,2,3 };
                var request = Builder<OrderRequest>.CreateNew().With(x => x.Time, time)
                                                               .With(x => x.OrderList, orderList).Build();

                var ex = Assert.Throws<Exception>(() => sut.TakeOrder(request));
                Assert.True(ex.Message.Equals("Time must have a value equal: morning or night"));
            }
            [Fact]
            public void When_RequestIsMorning_Expect_ValidObj()
            {
                var orderList = new List<int> { 1, 2, 3 };
                var request = Builder<OrderRequest>.CreateNew().With(x => x.Time, "morning")
                                                               .With(x => x.OrderList, orderList).Build();

                var testObj = Builder<Order>.CreateNew().Build();
                _orderService.TakeOrder(TimeEnum.Morning, Arg.Any<Dictionary<int, int>>()).Returns(testObj);

                var returnTest = sut.TakeOrder(request);

                Assert.True(returnTest != null);
                Assert.True(returnTest.Order.Contains(testObj.Entree));
                Assert.True(returnTest.Order.Contains(testObj.Side));
                Assert.True(returnTest.Order.Contains(testObj.Drink));
            }

            [Fact]
            public void When_RequestIsNight_Expect_ValidObj()
            {
                var orderList = new List<int> { 1, 2, 3 };
                var request = Builder<OrderRequest>.CreateNew().With(x => x.Time, "night")
                                                               .With(x => x.OrderList, orderList).Build();

                var testObj = Builder<Order>.CreateNew().Build();
                _orderService.TakeOrder(TimeEnum.Night, Arg.Any<Dictionary<int, int>>()).Returns(testObj);

                var returnTest = sut.TakeOrder(request);

                Assert.True(returnTest != null);
                Assert.True(returnTest.Order.Contains(testObj.Entree));
                Assert.True(returnTest.Order.Contains(testObj.Side));
                Assert.True(returnTest.Order.Contains(testObj.Drink));
            }            
        }
    }
}