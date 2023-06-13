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
    public interface IProdutoRepository
    {
        /// <summary>
        /// Método para cadastrar um produto
        /// </summary>
        void Create(Produto produto);

        /// <summary>
        /// Método para atualizar um produto
        /// </summary>
        void Update(Produto produto);

        /// <summary>
        /// Método para excluir um produto
        /// </summary>
        void Delete(Produto produto);

        /// <summary>
        /// Método para consultar os produtos
        /// </summary>
        List<Produto> GetAll();

        /// <summary>
        /// Método para consultar 1 produto através do ID
        /// </summary>
        Produto GetById(Guid idProduto);
    }
}
