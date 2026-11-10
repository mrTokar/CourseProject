using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.TemplateTypePages;

public class EditModel : PageModel
{
    private readonly PcshopContext _context;

    public EditModel(PcshopContext context)
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
        TemplateType = templatetype;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(TemplateType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TemplateTypeExists(TemplateType.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TemplateTypeExists(int id)
    {
        return _context.TemplateTypes.Any(e => e.Id == id);
    }
}
