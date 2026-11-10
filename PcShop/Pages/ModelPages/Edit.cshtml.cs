using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.ModelPages;

public class EditModel : PageModel
{
    private readonly PcshopContext _context;

    public EditModel(PcshopContext context)
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
        Model = model;
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

        _context.Attach(Model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ModelExists(Model.Id))
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

    private bool ModelExists(int id)
    {
        return _context.Models.Any(e => e.Id == id);
    }
}
