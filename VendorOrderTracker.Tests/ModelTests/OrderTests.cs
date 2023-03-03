using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTests
  {
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
  }
}
