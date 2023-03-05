using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetTitle_ReturnsGeneratedOrderTitleById_String()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      newOrder.Title = "Order" + newOrder.Id;
      Assert.AreEqual("Order1", newOrder.Title);
    }
    [TestMethod]
    public void GetDate_ReturnsOrderDate_String()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      Assert.AreEqual("3/3/23", newOrder.Date);
    }
    [TestMethod]
    public void GetId_ReturnsOrderId_Int()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      Assert.AreEqual(1, newOrder.Id);
    }
    [TestMethod]
    public void GetAll_ReturnsAllOrderObjects_OrderList()
    {
      Order newOrder1 = new Order("3/3/23", "unpaid");
      Order newOrder2 = new Order("3/3/23", "unpaid");
      List<Order> orderList = new List<Order> { newOrder1, newOrder2 };
      CollectionAssert.AreEqual(orderList, Order.GetAll());
    }
    [TestMethod]
    public void Find_ReturnsSpecificOrder_Order()
    {
      Order newOrder1 = new Order("3/3/23", "unpaid");
      Order newOrder2 = new Order("3/3/23", "unpaid");
      Assert.AreEqual(newOrder2, Order.Find(2));
    }
    [TestMethod]
    public void AddOrderDescription_AddsDescriptionToSpecifiedOrdersDictionary_Dictionary()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      Dictionary<string, int> orderDescription = new Dictionary<string, int> { {"pastries", 2 }, { "bread", 2 }, { "pastryTotal", 4 } };
      newOrder.AddOrderDescription(2, 2);
      Dictionary<string, int> result = newOrder.Description;
      CollectionAssert.AreEqual(orderDescription, result);
    }
    [TestMethod]
    public void CalculateBreadTotal_ReturnsCostOfBreadInOrder_Int()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      newOrder.AddOrderDescription(2, 3);
      int breadQuantity = newOrder.Description["bread"];
      int result = newOrder.CalculateBreadTotal(breadQuantity);
      Assert.AreEqual(10, result);
    }
    [TestMethod]
    public void CalculatePastryTotal_ReturnsCostOfPastriesInOrder_Int()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      newOrder.AddOrderDescription(4, 1);
      int pastryQuantity = newOrder.Description["pastries"];
      int result = newOrder.CalculatePastryTotal(pastryQuantity);
      Assert.AreEqual(6, result);
    }
    [TestMethod]
    public void GetTotal_ReturnsTotalCostOfOrder_Int()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      newOrder.AddOrderDescription(1, 1);
      Assert.AreEqual(7, newOrder.Total);
    }
    [TestMethod]
    public void Delete_DeletesSpecificOrderFromOrderList_Order()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      Order result = Order.Delete(1);
      Assert.AreEqual(result, newOrder);
    }
    [TestMethod]
    public void GetStatus_ReturnsOrderStatus_String()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      Assert.AreEqual("unpaid", newOrder.Status);
    }
    [TestMethod]
    public void AddOrderDescription_AddsDescriptionToSpecifiedOrdersDictionaryIncludingPastryTotal_Int()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      newOrder.AddOrderDescription(4, 2);
      int result = newOrder.Description["pastryTotal"];
      Assert.AreEqual(6, result);
    }
  }
}
