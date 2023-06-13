using ProdutosApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Interfaces
{
    /// <summary>
    /// Interface para as operações de Produto na camada de aplicação
    /// </summary>
    public interface IProdutoAppService
    {
        /// <summary>
        /// Método para cadastrar um produto
        /// </summary>
        void Create(ProdutoPostModel model);

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        void Update(ProdutoPutModel model);

        /// <summary>
        /// Método para excluir um produto
        /// </summary>
        void Delete(Guid id);

        /// <summary>
        /// Método para consultar todos os produtos
        /// </summary>
        List<ProdutoGetModel> GetAll();

        /// <summary>
        /// Método para consultar 1 produto através do ID
        /// </summary>
        ProdutoGetModel GetById(Guid id);
    }
}
