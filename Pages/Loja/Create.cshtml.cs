using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using chas_medicinais.Pages.Model;

namespace chas_medicinais.Pages.Loja
{
    public class CreateModel : PageModel
    {
        // 1.1 Acesso à ligação à base de dados
        private readonly ApplicationDbContext _db;

        // Elemento a inserir
        [BindProperty]
        public teas Tea { get; set; }

        // 2.1 Função Construtora -> Com o argumento - Dependency Injection
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // O que é preciso fazer quando a página é carregada?
        public void OnGet()
        {

        }

        // Form  Handler
        // Validação de Dados
        // Função executada quando o formulário é submetido.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)  // Válido de está de acordo com a tabela.
            {  // Cria o registo com os dados recebidos.
               // Na tabela "Livro" insere o objeto "livro"
               // Adiciona o registo à Base de Dados
                await _db.Tea.AddAsync(Tea);
                // Guardar as alterações na tabela
                // Deve ser sempre feito com o CREATE e o UPDATE e o DELETE
                await _db.SaveChangesAsync();
                // Redireciona para a página "Index".
                return RedirectToPage("Index");
            }
            else
            {
                // Se o modelo não é válido, 
                // mantém-se na própria página.
                return Page();
            }
        }
    }
}
