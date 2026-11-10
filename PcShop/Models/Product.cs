using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models;

public partial class Product
{
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Серийный номер")]
    [StringLength(32)]
    public string Id { get; set; } = null!;

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Модель")]
    public int Model { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Статус")]
    public ProductStatus Status { get; set; }

    [Range(0, 999999999.99, ErrorMessage = "Цена должна быть между 0 и 999999999.99")]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [DataType(DataType.Currency)]
    [Display(Name = "Цена")]
    [Column(TypeName = "decimal(12, 2)")]
    public decimal Price { get; set; }

  
    [Display(Name = "Местоположение")]
    public int? Location { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual Model? ModelNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
