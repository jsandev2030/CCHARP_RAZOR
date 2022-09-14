using System.ComponentModel.DataAnnotations;

namespace chas_medicinais.Pages.Model
{
    public class teas
    {
        // Definição da Chave primária. 
        [Key]
        public int Id { get; set; }

        // Campo "Titulo" - obrigatório.
        // [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }

        // Campo "Curas"
        // [Required(ErrorMessage = "O campo Curas é obrigatório")]
        public string Curas { get; set; }

        // Campo "Detalhes"
        // [Required(ErrorMessage = "O campo Detalhes é obrigatório")]
        public string Detalhes { get; set; }

        // Campo "Autor"
        // [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public string Autor { get; set; }

        // Campo "Imagem"
       // [Required(ErrorMessage = "O campo Imagem é obrigatório")]
        public string Imagem { get; set; }
    }
}
