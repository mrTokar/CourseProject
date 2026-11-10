using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.TemplateTypePages;

public class CreateModel : PageModel
{
    private readonly PcshopContext _context;

    public CreateModel(PcshopContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public TemplateType TemplateType { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TemplateTypes.Add(TemplateType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
