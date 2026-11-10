using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.TemplateTypePages;

public class DetailsModel : PageModel
{
    private readonly PcshopContext _context;
    public DetailsModel(PcshopContext context)
    {
        _context = context;
    }

    public TemplateType TemplateType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var templatetype = await _context.TemplateTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (templatetype is null)
        {
            return NotFound();
        }
        else
        {
            TemplateType = templatetype;
        }

        return Page();
    }
}
