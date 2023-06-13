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
    public class Categoria
    {
        #region Propriedades

        public Guid IdCategoria { get; set; }
        public string? Nome { get; set; }

        #endregion

        #region Relacionamentos

        public List<Produto>? Produtos { get; set; }

        #endregion
    }
}
