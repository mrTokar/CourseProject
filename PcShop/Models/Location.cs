using System;
using System.Collections.Generic;

namespace PcShop.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public string? Type { get; set; }

    public string? Schedules { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<User> UserLogins { get; set; } = new List<User>();
}
