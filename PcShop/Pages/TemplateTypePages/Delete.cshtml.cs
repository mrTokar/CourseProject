using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.TemplateTypePages;

public class DeleteModel : PageModel
{
    private readonly PcshopContext _context;

    public DeleteModel(PcshopContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var templatetype = await _context.TemplateTypes.FindAsync(id);
        if (templatetype != null)
        {
            TemplateType = templatetype;
            _context.TemplateTypes.Remove(TemplateType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
