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
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetTitle_ReturnsOrderTitle_String()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual("OrderTitle", newOrder.Title);
    }
    [TestMethod]
    public void GetDate_ReturnsOrderDate_String()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual("3/3/23", newOrder.Date);
    }
    [TestMethod]
    public void GetId_ReturnsOrderId_Int()
    {
      Order newOrder = new Order("OrderTitle", "3/3/23");
      Assert.AreEqual(1, newOrder.Id);
    }
  }
}
