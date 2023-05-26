using Microsoft.EntityFrameworkCore;
using RPA_Alura.Domain.Models;

namespace RPA_Alura.Repository.Data
{
    public class MeuDbContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MeuBancoEmMemoria");
        }
    }
}
