using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.LocationPages;

public class DeleteModel : PageModel
{
    private readonly PcshopContext _context;

    public DeleteModel(PcshopContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Location Location { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var location = await _context.Locations.FirstOrDefaultAsync(m => m.Id == id);
        if (location is null)
        {
            return NotFound();
        }
        else
        {
            Location = location;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var location = await _context.Locations.FindAsync(id);
        if (location != null)
        {
            Location = location;
            _context.Locations.Remove(Location);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
