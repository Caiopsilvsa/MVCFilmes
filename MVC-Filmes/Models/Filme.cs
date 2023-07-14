using System.ComponentModel.DataAnnotations;

namespace MVC_Filmes.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; } = string.Empty;
        [StringLength(30)]
        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Genero { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Lançamento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataDeLancamento { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Preco { get; set; }
        
        public int? Ponto { get; set; }
    }
}
