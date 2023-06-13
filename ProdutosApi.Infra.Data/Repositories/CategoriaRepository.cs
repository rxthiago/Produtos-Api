using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces.Repositories;
using ProdutosApi.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar o repositorio de categorias
    /// </summary>
    public class CategoriaRepository : ICategoriaRepository
    {
        public List<Categoria> GetAll()
        {
            using (var context = new SqlServerContext())
            {
                return context.Categoria
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Categoria GetById(Guid idCategoria)
        {
            using (var context = new SqlServerContext())
            {
                return context.Categoria.Find(idCategoria);
            }
        }
    }
}
