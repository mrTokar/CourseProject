using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.UserPages;

public class IndexModel : PageModel
{
    private readonly PcshopContext _context;

    public IndexModel(PcshopContext context)
    {
        _context = context;
    }

    public IList<User> User { get; set; } = default!;

    public async Task OnGetAsync()
    {
        User = await _context.Users.ToListAsync();
    }
}
