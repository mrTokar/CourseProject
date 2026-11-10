using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.LocationPages;

public class IndexModel : PageModel
{
    private readonly PcshopContext _context;

    public IndexModel(PcshopContext context)
    {
        _context = context;
    }

    public IList<Location> Location { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Location = await _context.Locations.ToListAsync();
    }
}
