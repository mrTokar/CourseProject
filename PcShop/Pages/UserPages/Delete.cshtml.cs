using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.UserPages;

public class DeleteModel : PageModel
{
    private readonly PcshopContext _context;

    public DeleteModel(PcshopContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(string? login)
    {
        if (login is null)
        {
            return NotFound();
        }

        var user = await _context.Users.FindAsync(login);
        if (user != null)
        {
            User = user;
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
