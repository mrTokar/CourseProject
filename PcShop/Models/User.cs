using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcShop.Models;

public partial class User
{
    [Key]
    [Display(Name = "Электронная почта")]
    [RegularExpression(@"^[a-z0-9_-]+(\.[a-z0-9_-]+)*@[a-z]+\.(ru|com)$",
        ErrorMessage = "Неверный адрес почты")]
    public string Login { get; set; } = null!;

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Пароль")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Фамилия")]
    [StringLength(30)]
    public string Surname { get; set; } = null!;

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Имя")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Display(Name = "Отчество")]
    [StringLength(30)]
    public string? Patronymic { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    public UserRole Status { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Location> IdLocations { get; set; } = new List<Location>();

    public virtual ICollection<Model> IdModels { get; set; } = new List<Model>();
}
