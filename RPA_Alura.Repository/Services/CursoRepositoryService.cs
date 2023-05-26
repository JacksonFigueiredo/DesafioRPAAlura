using Microsoft.EntityFrameworkCore;
using RPA_Alura.Domain.Models;
using RPA_Alura.Repository.Data;
using RPA_Alura.Repository.Interfaces;

namespace RPA_Alura.Repository.Services
{
    public class CursoRepositoryService : ICursoRepository
    {
        private readonly MeuDbContext _context;

        public CursoRepositoryService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Curso curso)
        {
            if (curso == null)
            {
                throw new ArgumentNullException(nameof(curso));
            }

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }
    }
}
