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
      order.Description["pastries"] = pastryCount;
      order.Description["bread"] = breadCount;
      int pastryTotal = order.CalculatePastryTotal(pastryCount);
      int breadTotal = order.CalculateBreadTotal(breadCount);
      order.Description["pastryCount"] = pastryTotal;
      order.Description["breadCount"] = breadTotal;
      order.Total = pastryTotal + breadTotal;
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View("Show", model);
    }
    [HttpGet("/vendors/{vendorId}/orders/{orderId}/updateqty")]
    public ActionResult UpdateQty(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
    [HttpPost("/orders/delete")]
    public ActionResult Delete(int orderId, int vendorId)
    {
      Order selectedOrder = Order.Find(orderId);
      Order.Delete(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      vendor.RemoveOrder(selectedOrder);
      return View(vendor);
    }
    [HttpPost("/orders/deleteall")]
    public ActionResult DeleteAll(int vendorId)
    {
      Vendor.DeleteAllOrders(vendorId);
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }
    [HttpGet("/vendors/{vendorId}/orders/{orderId}/updatestatus")]
    public ActionResult UpdateStatus(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
    [HttpPost("/orders/statuschange")]
    public ActionResult StatusChange(int vendorId, int orderId, string orderStatus)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      order.Status = orderStatus;
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
  }
}