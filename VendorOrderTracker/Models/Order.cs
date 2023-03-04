using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Date { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> {};
    public Dictionary<string, int> Description { get; set; }
    public int Total { get; set; }
    public Order(string title, string date)
    {
      Title = title;
      Date = date;
      _instances.Add(this);
      Id = _instances.Count;
      Description = new Dictionary<string, int> {};
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Order> GetAll ()
    {
      return _instances;
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    public void AddOrderDescription(int pastryOrder, int breadOrder)
    {
      Description.Add("pastries", pastryOrder);
      Description.Add("bread", breadOrder);
      int pastryQuantity = this.Description["pastries"];
      int breadQuantity = this.Description["bread"];
      int pastryTotal = this.CalculatePastryTotal(pastryQuantity);
      int breadTotal = this.CalculateBreadTotal(breadQuantity);
      this.Total = pastryTotal + breadTotal;
    }
    public int CalculateBreadTotal(int breadCount)
    {
      if(breadCount % 3 == 0)
      {
        return ((breadCount / 3) * 10);
      }
      else
      {
        int remainder = breadCount % 3;
        int adjustedCount = breadCount - remainder;
        return (remainder * 5) + ((adjustedCount / 3) * 10);
      }
    }
      public int CalculatePastryTotal(int pastryCount)
      {
        if(pastryCount % 4 == 0)
      {
        return ((pastryCount / 4) * 6);
      }
      else
      {
        int remainder = pastryCount % 4;
        int adjustedCount = pastryCount - remainder;
        return (remainder * 2) + ((adjustedCount / 4) * 6);
      }
    }
    public static Order Delete(int searchId)
    {
      Order order = Order.Find(searchId);
      _instances.Remove(order);
      return order;
    }
  }
}