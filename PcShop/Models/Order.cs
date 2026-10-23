using System;
using System.Collections.Generic;

namespace PcShop.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? Location { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime CreateDt { get; set; }

    public string? UserLogin { get; set; }

    public bool Paid { get; set; }

    public string? PaymentInfo { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual User? UserLoginNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
