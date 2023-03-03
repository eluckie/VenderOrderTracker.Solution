using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Date { get; set; }
    public Order(string title, string date)
    {
      Title = title;
      Date = date;
    }
  }
}