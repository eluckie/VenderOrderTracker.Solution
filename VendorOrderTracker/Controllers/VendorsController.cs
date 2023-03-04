using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }
    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/vendors")]
    public ActionResult Create(string name, string description)
    {
      Vendor newVendor = new Vendor(name, description);
      return RedirectToAction("Index");
    }
    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }
    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string title, string date, int pastryCount, int breadCount, string status)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};
      Vendor currentVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(title, date, status);
      newOrder.AddOrderDescription(pastryCount, breadCount);
      currentVendor.AddOrder(newOrder);
      List<Order> vendorOrders = currentVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", currentVendor);
      return View("Show", model);
    }
    [HttpPost("/vendors/{id}")]
    public ActionResult Create(int id, string name, string description)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};
      Vendor selectedVendor = Vendor.Find(id);
      selectedVendor.Name = name;
      selectedVendor.Description = description;
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View("Show", model);
    }
    [HttpGet("/vendors/{id}/update")]
    public ActionResult Update(int id)
    {
      Vendor selectedVendor = Vendor.Find(id);
      return View(selectedVendor);
    }
    [HttpPost("/vendors/deleteall")]
    public ActionResult DeleteAll()
    {
      Vendor.ClearAll();
      return View();
    }
    [HttpPost("/vendors/delete")]
    public ActionResult Delete(int vendorId)
    {
      Vendor selectedVendor = Vendor.Find(vendorId);
      Vendor.Delete(vendorId);
      return View(selectedVendor);
    }
  }
}