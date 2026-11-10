using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.UserPages;

public class DetailsModel : PageModel
{
    private readonly PcshopContext _context;
    public DetailsModel(PcshopContext context)
    {
        _context = context;
    }

    public User User { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? login)
    {
        if (login is null)
        {
            return NotFound();
        }

        var user = await _context.Users.FirstOrDefaultAsync(m => m.Login == login);
        if (user is null)
        {
            return NotFound();
        }
        else
        {
            User = user;
        }

        return Page();
    }
}
