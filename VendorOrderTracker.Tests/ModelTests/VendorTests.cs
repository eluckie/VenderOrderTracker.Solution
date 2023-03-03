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
  }
}