using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;
using ProdutosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Services
{
    /// <summary>
    /// Classe para implementar a interface ICategoriaAppService
    /// </summary>
    public class CategoriaAppService : ICategoriaAppService
    {
        //atributo
        private readonly ICategoriaDomainService _categoriaDomainService;

        //construtor para injeção de dependência (inicialização dos atributos)
        public CategoriaAppService(ICategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        public List<CategoriaGetModel> GetAll()
        {
            //consultar todas as categorias
            var categorias = _categoriaDomainService.GetAll();

            //criando uma lista de CategoriaGetModel
            var lista = new List<CategoriaGetModel>();

            //percorrer as categorias obtidas na consulta
            foreach (var item in categorias)
            {
                var model = new CategoriaGetModel
                {
                    IdCategoria = item.IdCategoria,
                    Nome = item.Nome
                };

                lista.Add(model); //adicionando na lista
            }

            return lista; //retornando a lista
        }
    }
}
