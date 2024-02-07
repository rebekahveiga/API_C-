using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Dataset;

public class FilmeContext : DbContext
{

    public FilmeContext(Microsoft.EntityFrameworkCore.DbContextOptions<FilmeContext> opts)
   : base(opts)
    {
    }


    public DbSet<Filme> Filmes { get; set; }


}
