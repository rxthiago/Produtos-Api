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
    /// Classe de serviços de domínio (regras de negócio) para categorias
    /// </summary>
    public class CategoriaDomainService : ICategoriaDomainService
    {
        //atributo
        private readonly ICategoriaRepository _categoriaRepository;

        //construtor para injeção de dependência
        public CategoriaDomainService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        private const string NaoHaCategoriasCadastradas = "Não há categorias cadastradas no sistema.";

        public List<Categoria> GetAll()
        {
            //consultar as categorias no banco de dados
            var categorias = _categoriaRepository.GetAll();

            //verificar se o resultado não é vazio
            if(categorias.Count() > 0)
            {
                return categorias; //retornando as categorias
            }
            else
            {
                //retornar um erro
                throw new ArgumentException(NaoHaCategoriasCadastradas);
            }
        }
    }
}
