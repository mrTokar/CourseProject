using System;
using System.Collections.Generic;

namespace PcShop.Models;

public partial class TemplateType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Specifications { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
