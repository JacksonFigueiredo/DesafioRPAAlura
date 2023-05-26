using RPA_Alura.Domain.Models;

namespace RPA_Alura.Repository.Interfaces
{
    public interface ICursoRepository
    {
        public Task AdicionarAsync(Curso curso);
        public Task<IEnumerable<Curso>> ObterTodosAsync();
 
    }
}
