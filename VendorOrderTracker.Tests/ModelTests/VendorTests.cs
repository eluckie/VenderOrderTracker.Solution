using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    [TestMethod]
    public void GetName_ReturnsVendorName_String()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual("CompanyName", newVendor.Name);
    }
    [TestMethod]
    public void GetDescription_ReturnsVendorDescription_String()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual("CompanyDescription", newVendor.Description);
    }
    [TestMethod]
    public void GetId_ReturnsVendorsId_Int()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Assert.AreEqual(1, newVendor.Id);
    }
    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      Vendor newVendor1 = new Vendor("CompanyName1", "CompanyDescription1");
      Vendor newVendor2 = new Vendor("CompanyName2", "CompanyDescription2");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
      CollectionAssert.AreEqual(newList, Vendor.GetAll());
    }
    [TestMethod]
    public void Find_ReturnsSpecificVendor_Vendor()
    {
      Vendor newVendor1 = new Vendor("CompanyName1", "CompanyDescription1");
      Vendor newVendor2 = new Vendor("CompanyName2", "CompanyDescription2");
      Assert.AreEqual(newVendor2, Vendor.Find(2));
    }
    [TestMethod]
    public void AddOrder_AddsOrderToSpecifiedVendorsList_OrderList()
    {
      Order newOrder = new Order("3/3/23", "unpaid");
      List<Order> orderList = new List<Order> { newOrder };
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      newVendor.AddOrder(newOrder);
      List<Order> result = newVendor.Orders;
      CollectionAssert.AreEqual(orderList, result);
    }
    [TestMethod]
    public void Delete_DeletesSpecificVendorFromVendorsList_Vendor()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Vendor result = Vendor.Delete(1);
      Assert.AreEqual(result, newVendor);
    }
    [TestMethod]
    public void RemoveOrder_RemovesOrderToSpecifiedVendorsList_OrderList()
    {
      Order newOrder1 = new Order("3/3/23", "unpaid");
      Order newOrder2 = new Order("3/3/23", "unpaid");
      List<Order> orderList = new List<Order> { newOrder2 };
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      newVendor.AddOrder(newOrder1);
      newVendor.AddOrder(newOrder2);
      newVendor.RemoveOrder(newOrder1);
      List<Order> result = newVendor.Orders;
      CollectionAssert.AreEqual(orderList, result);
    }
    [TestMethod]
    public void DeleteAllOrders_DeletesAllOrdersFromSpecifiedVendor_OrderList()
    {
      Vendor newVendor = new Vendor("CompanyName", "CompanyDescription");
      Order newOrder = new Order("3/3/23", "unpaid");
      Order newOrder2 = new Order("3/3/23", "unpaid");
      newVendor.AddOrder(newOrder);
      newVendor.AddOrder(newOrder2);
      Vendor.DeleteAllOrders(1);
      List<Order> orderList = new List<Order> {};
      List<Order> result = newVendor.Orders;
      CollectionAssert.AreEqual(orderList, result);
    }
  }
}