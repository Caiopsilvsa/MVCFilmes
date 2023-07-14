using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Filmes.Models
{
    public class FilmeViewModel
    {
        public List<Filme>? Filmes { get; set; }
        public string? FilmeDigitado { get; set; }
        public string? GeneroEscolhido { get; set; }
        public SelectList? Generos { get; set; }

    }
}
