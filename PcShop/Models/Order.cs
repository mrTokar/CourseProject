using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models;

public partial class Order
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Местоположение")]
    public int? Location { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Статус")]
    public OrderStatus Status { get; set; }

    [Range(0, 999999999.99, ErrorMessage = "Цена должна быть между 0 и 999999999.99")]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [DataType(DataType.Currency)]
    [Display(Name = "Цена")]
    [Column(TypeName = "decimal(12, 2)")]
    public decimal TotalPrice { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [DataType(DataType.DateTime)]
    [Display(Name = "Дата создания")]   
    public DateTime CreateDt { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Почта пользователя")]
    [StringLength(256)]
    [RegularExpression(@"^[a-z0-9_-]+(\.[a-z0-9_-]+)*@[a-z]+\.(ru|com)$",
        ErrorMessage = "Неверный формат почты")]
    public string? UserLogin { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    public PaymentType Payment { get; set; }

    public bool Paid { get; set; }

    public string? PaymentInfo { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual User? UserLoginNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
