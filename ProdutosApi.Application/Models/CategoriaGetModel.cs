namespace ProdutosApi.Application.Models
{
    /// <summary>
    /// Classe para retornar os dados da consulta de categorias
    /// </summary>
    public class CategoriaGetModel
    {
        public Guid IdCategoria { get; set; }
        public string? Nome { get; set; }
    }
}
