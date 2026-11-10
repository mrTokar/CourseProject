using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.ModelPages;

public class DeleteModel : PageModel
{
    private readonly PcshopContext _context;

    public DeleteModel(PcshopContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Model Model { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var model = await _context.Models.FirstOrDefaultAsync(m => m.Id == id);
        if (model is null)
        {
            return NotFound();
        }
        else
        {
            Model = model;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var model = await _context.Models.FindAsync(id);
        if (model != null)
        {
            Model = model;
            _context.Models.Remove(Model);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
