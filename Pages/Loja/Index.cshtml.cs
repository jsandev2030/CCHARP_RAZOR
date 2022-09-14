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
        // 1.1 Acesso à ligação da base de dados
        private readonly ApplicationDbContext _db;

        // Para obter a lista de Chás 
        public IEnumerable<teas> Tea { get; set; }

        // 2.1 Função Construtora -> Com o argumento - Dependency Injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;   // Dependency Injection
        }

        public async Task OnGet()
        {
            Tea = await _db.Tea.ToListAsync();
            // "Tea" -> tabela.
            // Carrega os registos da tabela para o vetor "teas".
            // "await" - Permite a execução de outras atividades
            // enquanto espera.
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            // 1. Obter o chá a apagar através do seu "id"
            var tea = await _db.Tea.FindAsync(id);

            // 2. Se não existir
            if (tea == null)
            {
                return NotFound();
            }
            // 3. Se exitir: apaga e guarda alterações
            _db.Tea.Remove(tea);
            await _db.SaveChangesAsync();

            // 4. Recarrgar a página "Index".
            return RedirectToPage("Index");
        }

    }
}
