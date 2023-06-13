using Microsoft.EntityFrameworkCore;
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
    /// Classe para implementar o repositorio de produtos
    /// </summary>
    public class ProdutoRepository : IProdutoRepository
    {
        public void Create(Produto produto)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(produto).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Produto produto)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Produto produto)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(produto).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Produto> GetAll()
        {
            using (var context = new SqlServerContext())
            {
                return context.Produto
                    .Include(p => p.Categoria) //JOIN
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        public Produto GetById(Guid idProduto)
        {
            using (var context = new SqlServerContext())
            {
                return context.Produto
                    .Include(p => p.Categoria) //JOIN
                    .FirstOrDefault(p => p.IdProduto.Equals(idProduto));
            }
        }
    }
}
