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
using GFTTest.Domain.Orders.Services;

namespace GFTTest.Tests
{
    public class ServiceTests
    {
        private readonly OrderService sut;

        public ServiceTests()
        {
            sut = new OrderService();
        }

        public class TakeOrderMethod : ServiceTests
        {
            [Theory]
            [InlineData(TimeEnum.Morning)]
            [InlineData(TimeEnum.Night)]
            public void When_OrderListIsNull_Expect_EmptyOrder(TimeEnum time)
            {
                var testObj = sut.TakeOrder(time, null);
                Assert.NotNull(testObj);
                Assert.True(testObj.Entree == null);
                Assert.True(testObj.Dessert == null);
                Assert.True(testObj.Drink == null);
                Assert.True(testObj.Side == null);
            }

            [Fact]
            public void When_OrderListMorningContainsError1_Expect_OrderWithErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 2);
                var testObj = sut.TakeOrder(TimeEnum.Morning, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListMorningContainsError2_Expect_OrderWithErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 2);
                orderList.Add(3, 1);

                var testObj = sut.TakeOrder(TimeEnum.Morning, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListMorningContainsError4_Expect_OrderWithErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 1);
                orderList.Add(3, 2);
                orderList.Add(4, 1);

                var testObj = sut.TakeOrder(TimeEnum.Morning, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListMorningContainsNoError_Expect_OrderWithoutErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 1);
                orderList.Add(3, 2);

                var testObj = sut.TakeOrder(TimeEnum.Morning, orderList);
                Assert.NotNull(testObj);
                Assert.NotNull(testObj);
                Assert.Contains("eggs", testObj.ToString());
                Assert.Contains("toast", testObj.ToString());
                Assert.Contains("coffee", testObj.ToString());
            }

            [Fact]
            public void When_OrderListMorningContainsNoMapped_Expect_OrderWithoutErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 1);
                orderList.Add(3, 1);
                orderList.Add(4, 1);
                orderList.Add(5, 1);


                var testObj = sut.TakeOrder(TimeEnum.Night, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("steak", testObj.ToString());
                Assert.Contains("potato", testObj.ToString());
                Assert.Contains("wine", testObj.ToString());
                Assert.Contains("cake", testObj.ToString());
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListNigthContainsError1_Expect_OrderWithErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 2);
                var testObj = sut.TakeOrder(TimeEnum.Morning, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListNigthContainsError3_Expect_OrderWithErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 2);
                orderList.Add(3, 2);

                var testObj = sut.TakeOrder(TimeEnum.Night, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListNigthContainsError4_Expect_OrderWithErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 1);
                orderList.Add(3, 1);
                orderList.Add(4, 2);

                var testObj = sut.TakeOrder(TimeEnum.Night, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("error", testObj.ToString());
            }

            [Fact]
            public void When_OrderListNigthContainsNoError_Expect_OrderWithoutErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 1);
                orderList.Add(3, 1);
                orderList.Add(4, 1);

                var testObj = sut.TakeOrder(TimeEnum.Night, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("steak", testObj.ToString());
                Assert.Contains("potato", testObj.ToString());
                Assert.Contains("wine", testObj.ToString());
                Assert.Contains("cake", testObj.ToString());
            }
            [Fact]
            public void When_OrderListNigthContainsNoMapped_Expect_OrderWithoutErrorString()
            {
                var orderList = new Dictionary<int, int>();
                orderList.Add(1, 1);
                orderList.Add(2, 1);
                orderList.Add(3, 1);
                orderList.Add(4, 1);
                orderList.Add(5, 1);


                var testObj = sut.TakeOrder(TimeEnum.Night, orderList);
                Assert.NotNull(testObj);
                Assert.Contains("steak", testObj.ToString());
                Assert.Contains("potato", testObj.ToString());
                Assert.Contains("wine", testObj.ToString());
                Assert.Contains("cake", testObj.ToString());
                Assert.Contains("error", testObj.ToString());
            }
        }
    }
}
