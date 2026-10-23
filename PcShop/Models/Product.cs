using System;
using System.Collections.Generic;

namespace PcShop.Models;

public partial class Product
{
    public string Id { get; set; } = null!;

    public int Model { get; set; }

    public ProductStatus Status { get; set; }

    public decimal? Price { get; set; }

    public int? Location { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual Model ModelNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
