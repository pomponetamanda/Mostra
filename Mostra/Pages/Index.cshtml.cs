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

    public IList<mostra> clientes { get; set; }
    public async Task OnGetAsync()
    {
        clientes = await _context.clientes.ToListAsync();
    }

    public async Task<IActionResult> OnPostAddAsync(mostra newmostra)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _context.clientes.Add(newmostra);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int Id)
    {
        var mostra = await _context.clientes.FindAsync(Id);
        if (mostra != null)
        {
            _context.clientes.Remove(mostra);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}