using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mostra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<mostra> cadastro { get; set; }
    public async Task OnGetAsync()
    {
        cadastro = await _context.cadastro.ToListAsync();
    }

    public async Task<IActionResult> OnPostAddAsync(mostra newmostra)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _context.cadastro.Add(newmostra);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var mostra = await _context.cadastro.FindAsync(id);
        if (mostra != null)
        {
            _context.cadastro.Remove(mostra);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}