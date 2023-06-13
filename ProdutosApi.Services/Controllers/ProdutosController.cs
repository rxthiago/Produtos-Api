using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ProdutosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        //atributo
        private readonly IProdutoAppService _produtoAppService;

        //construtor para injeção de dependência (inicialização dos atributos)
        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        /// <summary>
        /// Método de serviço para incluir um produto
        /// </summary>
        [HttpPost]
        public IActionResult Post(ProdutoPostModel model)
        {
            try
            {
                _produtoAppService.Create(model);

                return StatusCode(201, new { mensagem = "Produto cadastrado com sucesso." });
            }
            catch(ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        /// <summary>
        /// Método de serviço para atualizar um produto
        /// </summary>
        [HttpPut]
        public IActionResult Put(ProdutoPutModel model)
        {
            try
            {
                _produtoAppService.Update(model);

                return StatusCode(200, new { mensagem = "Produto atualizado com sucesso." });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        /// <summary>
        /// Método de serviço para excluir um produto
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoAppService.Delete(id);

                return StatusCode(200, new { mensagem = "Produto excluído com sucesso." });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        /// <summary>
        /// Método de serviço para consulta de produtos
        /// </summary>
        [ProducesResponseType(200, Type = typeof(List<ProdutoGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = _produtoAppService.GetAll();
                return StatusCode(200, lista);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        /// <summary>
        /// Método de serviço para consulta de 1 produto baseado no ID
        /// </summary>
        [ProducesResponseType(200, Type = typeof(ProdutoGetModel))]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var model = _produtoAppService.GetById(id);
                return StatusCode(200, model);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }
    }
}
