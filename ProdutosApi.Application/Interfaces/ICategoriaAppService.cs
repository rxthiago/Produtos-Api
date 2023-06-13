using ProdutosApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Interfaces
{
    /// <summary>
    /// Interface para as operações de Categoria na camada de aplicação
    /// </summary>
    public interface ICategoriaAppService
    {
        /// <summary>
        /// Método para retornar uma consulta de categorias
        /// </summary>
        List<CategoriaGetModel> GetAll();
    }
}
