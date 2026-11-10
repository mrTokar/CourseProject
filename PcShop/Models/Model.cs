using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models;

public partial class Model
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Название")]
    [StringLength(100)]
    public string Name { get; set; } = null!;


    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Тип")]
    public int Type { get; set; }

    [Range(0, 999999999.99, ErrorMessage = "Цена должна быть между 0 и 999999999.99")]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [DataType(DataType.Currency)]
    [Display(Name = "Цена")]
    [Column(TypeName = "decimal(12, 2)")]
    public decimal Price { get; set; }

    [Display(Name = "Ссылка на изображение")]
    [DataType(DataType.ImageUrl)]
    [RegularExpression(@"^https?://[^\s/$.?#].[^\s]*\.(jpe?g|png|webp|gif|svg|avif)(\?.*)?$",
        ErrorMessage = "Неверный формат ссылки на изображение")]
    public string? Image { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Производитель")]
    [StringLength(10)]
    public string Fabric { get; set; } = null!;

    //[Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Характеристики")]
    public string? Specifications { get; set; }

    [Range(0, 99999)]
    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Количество")]
    public int Count { get; set; }

 
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual TemplateType? TypeNavigation { get; set; }

}
