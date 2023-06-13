using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Entities
{
    /// <summary>
    /// Entidade de domínio
    /// </summary>
    public class Produto
    {
        #region Propriedades

        public Guid IdProduto { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid IdCategoria { get; set; }

        #endregion

        #region Relacionamentos

        public Categoria? Categoria { get; set; }

        #endregion
    }
}
