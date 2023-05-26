using RPA_Alura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPA_Alura.Repository.Interfaces
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
    }
}
