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
        // 1.1 Acesso � liga��o � base de dados
        private readonly ApplicationDbContext _db;

        // Elemento a inserir
        [BindProperty]
        public teas Tea { get; set; }

        // 2.1 Fun��o Construtora -> Com o argumento - Dependency Injection
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // O que � preciso fazer quando a p�gina � carregada?
        public void OnGet()
        {

        }

        // Form  Handler
        // Valida��o de Dados
        // Fun��o executada quando o formul�rio � submetido.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)  // V�lido de est� de acordo com a tabela.
            {  // Cria o registo com os dados recebidos.
               // Na tabela "Livro" insere o objeto "livro"
               // Adiciona o registo � Base de Dados
                await _db.Tea.AddAsync(Tea);
                // Guardar as altera��es na tabela
                // Deve ser sempre feito com o CREATE e o UPDATE e o DELETE
                await _db.SaveChangesAsync();
                // Redireciona para a p�gina "Index".
                return RedirectToPage("Index");
            }
            else
            {
                // Se o modelo n�o � v�lido, 
                // mant�m-se na pr�pria p�gina.
                return Page();
            }
        }
    }
}
