using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;
using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Services
{
    /// <summary>
    /// Classe para implementar a interface IProdutoAppService
    /// </summary>
    public class ProdutoAppService : IProdutoAppService
    {
        //atributo
        private readonly IProdutoDomainService _produtoDomainService;

        //construtor para injeção de dependência (inicialização dos atributos)
        public ProdutoAppService(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }

        public void Create(ProdutoPostModel model)
        {
            //criando um objeto da classe de entidade
            var produto = new Produto()
            {
                Nome = model.Nome,
                Preco = model.Preco.Value,
                Quantidade = model.Quantidade.Value,
                IdCategoria= model.IdCategoria.Value
            };

            //realizar o cadastro do produto
            _produtoDomainService.Create(produto);
        }

        public void Update(ProdutoPutModel model)
        {
            //criando um objeto da classe de entidade
            var produto = new Produto()
            {
                IdProduto = model.IdProduto.Value,
                Nome = model.Nome,
                Preco = model.Preco.Value,
                Quantidade = model.Quantidade.Value,
                IdCategoria = model.IdCategoria.Value
            };

            //realizar a atualização do produto
            _produtoDomainService.Update(produto);
        }

        public void Delete(Guid id)
        {
            //realizar a exclusão do produto
            _produtoDomainService.Delete(id);
        }

        public List<ProdutoGetModel> GetAll()
        {
            //consultar os produtos cadastrados
            var produtos = _produtoDomainService.GetAll();

            //criando uma lista da classe ProdutoGetModel
            var lista = new List<ProdutoGetModel>();

            //percorrer a consulta obtida do dominio
            foreach (var item in produtos)
            {
                var model = new ProdutoGetModel()
                {
                    IdProduto = item.IdProduto,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade,
                    Total = (item.Preco * item.Quantidade),
                    DataHoraCadastro = item.DataHoraCadastro,
                    Categoria = new CategoriaGetModel
                    {
                        IdCategoria = item.Categoria.IdCategoria,
                        Nome = item.Categoria.Nome
                    }
                };

                lista.Add(model); //adicionando na lista
            }

            return lista; //retornando a lista
        }

        public ProdutoGetModel GetById(Guid id)
        {
            //pesquisar 1 produto baseado no ID
            var produto = _produtoDomainService.GetById(id);

            //transferir os dados do produto para um objeto ProdutoGetModel
            var model = new ProdutoGetModel
            {
                IdProduto = produto.IdProduto,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = (produto.Preco * produto.Quantidade),
                DataHoraCadastro = produto.DataHoraCadastro,
                Categoria = new CategoriaGetModel
                {
                    IdCategoria = produto.Categoria.IdCategoria,
                    Nome = produto.Categoria.Nome
                }
            };

            return model; //retornando o modelo
        }
    }
}
