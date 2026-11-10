using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.OrderPages;

public class IndexModel : PageModel
{
    private readonly PcshopContext _context;

    public IndexModel(PcshopContext context)
    {
        _context = context;
    }

    public IList<Order> Order { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Order = await _context.Orders.ToListAsync();
    }
}
