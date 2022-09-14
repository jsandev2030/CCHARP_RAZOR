using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chas_medicinais.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace chas_medicinais.Pages.Loja
{
    public class IndexModel : PageModel
    {
        // 1.1 Acesso � liga��o da base de dados
        private readonly ApplicationDbContext _db;

        // Para obter a lista de Ch�s 
        public IEnumerable<teas> Tea { get; set; }

        // 2.1 Fun��o Construtora -> Com o argumento - Dependency Injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;   // Dependency Injection
        }

        public async Task OnGet()
        {
            Tea = await _db.Tea.ToListAsync();
            // "Tea" -> tabela.
            // Carrega os registos da tabela para o vetor "teas".
            // "await" - Permite a execu��o de outras atividades
            // enquanto espera.
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            // 1. Obter o ch� a apagar atrav�s do seu "id"
            var tea = await _db.Tea.FindAsync(id);

            // 2. Se n�o existir
            if (tea == null)
            {
                return NotFound();
            }
            // 3. Se exitir: apaga e guarda altera��es
            _db.Tea.Remove(tea);
            await _db.SaveChangesAsync();

            // 4. Recarrgar a p�gina "Index".
            return RedirectToPage("Index");
        }

    }
}
