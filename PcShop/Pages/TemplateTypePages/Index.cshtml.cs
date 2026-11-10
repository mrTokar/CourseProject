using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PcShop.Models;

namespace PcShop.Pages.TemplateTypePages;

public class IndexModel : PageModel
{
    private readonly PcshopContext _context;

    public IndexModel(PcshopContext context)
    {
        _context = context;
    }

    public IList<TemplateType> TemplateType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        TemplateType = await _context.TemplateTypes.ToListAsync();
    }
}
