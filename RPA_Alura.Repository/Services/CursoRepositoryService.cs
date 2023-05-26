using Microsoft.EntityFrameworkCore;
using RPA_Alura.Domain.Models;
using RPA_Alura.Repository.Data;
using RPA_Alura.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA_Alura.Repository.Services
{
    public class CursoRepositoryService : ICursoRepository
    {
        private readonly MeuDbContext _context;

        public CursoRepositoryService(MeuDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Curso curso)
        {
            if (curso == null)
            {
                throw new ArgumentNullException(nameof(curso));
            }

            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }
    }
}
