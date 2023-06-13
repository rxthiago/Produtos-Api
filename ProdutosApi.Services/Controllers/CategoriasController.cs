using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;

namespace ProdutosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        //atributo
        private readonly ICategoriaAppService _categoriaAppService;

        //construtor para injeção de dependência (inicialização dos atributos)
        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        /// <summary>
        /// Serviço para retornar todas as categorias cadastradas no sistema
        /// </summary>
        [ProducesResponseType(200, Type = typeof(List<CategoriaGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {                
                var lista = _categoriaAppService.GetAll();
                return StatusCode(200, lista); //STATUS 200 (OK)
            }
            catch(ArgumentException e)
            {
                //STATUS 400 (BAD REQUEST)
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch(Exception e)
            {
                //STATUS 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }
    }
}
