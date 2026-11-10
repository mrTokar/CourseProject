using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcShop.Models;

public partial class Location
{
    public int Id { get; set; }

    [StringLength(25)]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Город")]
    public string City { get; set; }

    [StringLength(40)]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Улица")]
    public string Street { get; set; }

    [StringLength(5)]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Дом")]
    public string House { get; set; }

    [RegularExpression(@"^(ПВЗ|магазин|склад)$", 
        ErrorMessage = "Допустимы только ПВЗ, магазин, склад")]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Тип")]
    public string Type { get; set; }

    public string? Schedules { get; set; }

    //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    //public virtual ICollection<User> UserLogins { get; set; } = new List<User>();
}
