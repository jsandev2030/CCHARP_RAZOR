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
        // 1.1 Acesso à ligação à base de dados
        private ApplicationDbContext _db;

        // Elemento a atualizar
        [BindProperty]
        public teas Tea { get; set; }

        // 2.1 Função Construtora "ctor" - para rapidez -> Com o argumento - Dependency Injection
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            // Obtém os dados do chá de acordo com o seu Id
            Tea = await _db.Tea.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            // Se o modelo está
            // Válido ou seja, se está de acordo com a tabela.
            if (ModelState.IsValid)
            {
                // Localiza o objeto com o "Id"
                // passado com o evento do clique no botão
                // da base de dados
                var TeaFromDb = await _db.Tea.FindAsync(Tea.Id);
                // Obtém os dados dos controlos
                // para a o objeto da base de dados
                TeaFromDb.Titulo = Tea.Titulo;
                TeaFromDb.Curas = Tea.Curas;
                TeaFromDb.Detalhes = Tea.Detalhes;
                TeaFromDb.Autor = Tea.Autor;
                TeaFromDb.Imagem = Tea.Imagem;

                // Grava o objeto na base de dados.
                // Atualização do livro na base de dados
                await _db.SaveChangesAsync();

                // Redireciona para a página "Index"
                return RedirectToPage("Index");
            }

            // Se não for válido, mantém-se na página atual.
            return RedirectToPage();
        }
    }
}
