using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.LocationPages;

public class DetailsModel : PageModel
{
    private readonly PcshopContext _context;
    public DetailsModel(PcshopContext context)
    {
        _context = context;
    }

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
}
