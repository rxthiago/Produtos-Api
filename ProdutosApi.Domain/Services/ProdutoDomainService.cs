using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces.Repositories;
using ProdutosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Services
{
    /// <summary>
    /// Classe de serviços de domínio (regras de negócio) para produtos
    /// </summary>
    public class ProdutoDomainService : IProdutoDomainService
    {
        //atributos
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        //método construtor para injeção de dependência
        public ProdutoDomainService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        //mensagens de erro
        private const string ProdutoNaoEncontrado = "O Produto informado não foi encontrado.";
        private const string NaoHaProdutosCadastrados = "Não há produtos cadastrados no sistema.";
        private const string CategoriaNaoEncontrada = "A Categoria informada não foi encontrada.";
        private const string PrecoInvalido = "O preço não pode ser menor ou igual a zero.";

        public void Create(Produto produto)
        {
            //Verificar se a categoria informada não existe no banco de dados
            if(_categoriaRepository.GetById(produto.IdCategoria) == null)
            {
                throw new ArgumentException(CategoriaNaoEncontrada);
            }

            //Verificar se o preço é menor ou igual a zero
            if(produto.Preco <= 0)
            {
                throw new ArgumentException(PrecoInvalido);
            }

            //Gerar o id do produto
            produto.IdProduto = Guid.NewGuid();
            //Gerar a data e hora de cadastro do produto
            produto.DataHoraCadastro = DateTime.Now;

            //Realizando o cadastro do produto
            _produtoRepository.Create(produto);
        }

        public void Update(Produto produto)
        {
            //Verificar se o produto informado não existe no banco de dados
            if (_produtoRepository.GetById(produto.IdProduto) == null)
            {
                throw new ArgumentException(ProdutoNaoEncontrado);
            }

            //Verificar se a categoria informada não existe no banco de dados
            if (_categoriaRepository.GetById(produto.IdCategoria) == null)
            {
                throw new ArgumentException(CategoriaNaoEncontrada);
            }

            //Verificar se o preço é menor ou igual a zero
            if (produto.Preco <= 0)
            {
                throw new ArgumentException(PrecoInvalido);
            }

            _produtoRepository.Update(produto);
        }

        public void Delete(Guid idProduto)
        {
            //buscar o produto no banco de dados através do ID
            var produto = _produtoRepository.GetById(idProduto);

            //Verificar se o produto informado existe no banco de dados
            if(produto != null)
            {
                //excluindo o produto
                _produtoRepository.Delete(produto);
            }
            else
            {
                throw new ArgumentException(ProdutoNaoEncontrado);
            }
        }

        public List<Produto> GetAll()
        {
            //consultando os produtos no banco de dados
            var produtos = _produtoRepository.GetAll();

            //verificando se algum produto foi encontrado
            if(produtos.Count() > 0)
            {
                return produtos; //retornando os produtos
            }
            else
            {
                throw new ArgumentException(NaoHaProdutosCadastrados);
            }
        }

        public Produto GetById(Guid idProduto)
        {
            //consultando o produto no banco de dados através do ID
            var produto = _produtoRepository.GetById(idProduto);

            //verificando se o produto foi encontrado
            if(produto != null)
            {
                return produto; //retornando o produto
            }
            else
            {
                throw new ArgumentException(ProdutoNaoEncontrado);
            }
        }
    }
}
