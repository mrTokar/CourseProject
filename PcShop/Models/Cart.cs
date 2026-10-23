using System;
using System.Collections.Generic;

namespace PcShop.Models;

public partial class Cart
{
    public string UserLogin { get; set; } = null!;

    public int IdModel { get; set; }

    public decimal Count { get; set; }

    public virtual Model IdModelNavigation { get; set; } = null!;

    public virtual User UserLoginNavigation { get; set; } = null!;
}
