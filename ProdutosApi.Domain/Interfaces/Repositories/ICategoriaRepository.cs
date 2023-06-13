using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para definir os métodos do repositório de categorias
    /// </summary>
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Método para consultar todas as categorias
        /// </summary>
        List<Categoria> GetAll();

        /// <summary>
        /// Método para consultar 1 categoria através do ID
        /// </summary>
        Categoria GetById(Guid idCategoria);
    }
}
