using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.ProductPages;

public class DetailsModel : PageModel
{
    private readonly PcshopContext _context;
    public DetailsModel(PcshopContext context)
    {
        _context = context;
    }

    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        if (product is null)
        {
            return NotFound();
        }
        else
        {
            Product = product;
        }

        return Page();
    }
}
