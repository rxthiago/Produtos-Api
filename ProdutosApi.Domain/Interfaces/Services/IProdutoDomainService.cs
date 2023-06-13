using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para os métodos de serviço de dominio de produto
    /// </summary>
    public interface IProdutoDomainService
    {
        /// <summary>
        /// Método para cadastrar produtos
        /// </summary>
        void Create(Produto produto);

        /// <summary>
        /// Método para atualizar produtos
        /// </summary>
        void Update(Produto produto);

        /// <summary>
        /// Método para excluir produtos
        /// </summary>
        void Delete(Guid idProduto);

        /// <summary>
        /// Método para consultar todos os produtos
        /// </summary>
        List<Produto> GetAll();

        /// <summary>
        /// Método para consultar 1 produto atraves do ID
        /// </summary>
        Produto GetById(Guid idProduto);
    }
}
