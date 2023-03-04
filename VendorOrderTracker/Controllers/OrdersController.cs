using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;
using System.Collections.Generic;

namespace VendorOrderTracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }
    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
    [HttpPost("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Create(int vendorId, int orderId, int pastryCount, int breadCount)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      int pastryTotal = order.CalculatePastryTotal(pastryCount);
      int breadTotal = order.CalculateBreadTotal(breadCount);
      order.Total = pastryTotal + breadTotal;
      order.Description["pastries"] = pastryCount;
      order.Description["bread"] = breadCount;
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View("Show", model);
    }
    [HttpGet("/vendors/{vendorId}/orders/{orderId}/update")]
    public ActionResult Update(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
    [HttpPost("orders/delete")]
    public ActionResult Delete(int orderId, int vendorId)
    {
      Order selectedOrder = Order.Find(orderId);
      Order.Delete(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      vendor.RemoveOrder(selectedOrder);
      return View(vendor);
    }
  }
}