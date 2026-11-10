using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PcShop.Models;

public partial class TemplateType
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязтаельное поле для заполнения")]
    [Display(Name = "Название")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    public string? Specifications { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
