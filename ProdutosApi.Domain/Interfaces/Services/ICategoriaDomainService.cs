using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para os métodos de serviço de dominio de categoria
    /// </summary>
    public interface ICategoriaDomainService
    {
        /// <summary>
        /// Consultar todas as categorias cadastradas
        /// </summary>
        List<Categoria> GetAll();
    }
}
