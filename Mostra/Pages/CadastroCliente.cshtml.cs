using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Mostra.Models;

namespace Mostra.Pages
{
    public class CadastroClienteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CadastroClienteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public mostra mostra { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.clientes.Add(mostra);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}