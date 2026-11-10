using System;
using System.Collections.Generic;

namespace PcShop.Models;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public decimal? Price { get; set; }

    public string? Image { get; set; }

    public string Fabric { get; set; } = null!;

    public string? Specifications { get; set; }

    public decimal Count { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual TemplateType TypeNavigation { get; set; } = null!;

}
