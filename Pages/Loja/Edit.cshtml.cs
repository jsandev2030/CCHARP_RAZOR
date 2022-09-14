using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chas_medicinais.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace chas_medicinais.Pages.Loja
{
    public class EditModel : PageModel
    {
        // 1.1 Acesso � liga��o � base de dados
        private ApplicationDbContext _db;

        // Elemento a atualizar
        [BindProperty]
        public teas Tea { get; set; }

        // 2.1 Fun��o Construtora "ctor" - para rapidez -> Com o argumento - Dependency Injection
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            // Obt�m os dados do ch� de acordo com o seu Id
            Tea = await _db.Tea.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            // Se o modelo est�
            // V�lido ou seja, se est� de acordo com a tabela.
            if (ModelState.IsValid)
            {
                // Localiza o objeto com o "Id"
                // passado com o evento do clique no bot�o
                // da base de dados
                var TeaFromDb = await _db.Tea.FindAsync(Tea.Id);
                // Obt�m os dados dos controlos
                // para a o objeto da base de dados
                TeaFromDb.Titulo = Tea.Titulo;
                TeaFromDb.Curas = Tea.Curas;
                TeaFromDb.Detalhes = Tea.Detalhes;
                TeaFromDb.Autor = Tea.Autor;
                TeaFromDb.Imagem = Tea.Imagem;

                // Grava o objeto na base de dados.
                // Atualiza��o do livro na base de dados
                await _db.SaveChangesAsync();

                // Redireciona para a p�gina "Index"
                return RedirectToPage("Index");
            }

            // Se n�o for v�lido, mant�m-se na p�gina atual.
            return RedirectToPage();
        }
    }
}
