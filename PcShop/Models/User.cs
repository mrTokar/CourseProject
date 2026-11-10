using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcShop.Models;

public partial class User
{
    [Key]
    public string Login { get; set; } = null!;  

    public string Password { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public UserRole Status { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Location> IdLocations { get; set; } = new List<Location>();

    public virtual ICollection<Model> IdModels { get; set; } = new List<Model>();
}
