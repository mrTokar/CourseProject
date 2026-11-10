using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.ModelPages;

public class IndexModel : PageModel
{
    private readonly PcshopContext _context;

    public IndexModel(PcshopContext context)
    {
        _context = context;
    }

    public IList<Model> Model { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Model = await _context.Models.ToListAsync();
    }
}
