using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Filmes.Models;

namespace MVC_Filmes.Data
{
    public class MVC_FilmesContext : DbContext
    {
        public MVC_FilmesContext (DbContextOptions<MVC_FilmesContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Filmes.Models.Filme> Filme { get; set; } = default!;
    }
}
