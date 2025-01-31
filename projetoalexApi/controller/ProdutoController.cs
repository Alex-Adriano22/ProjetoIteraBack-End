
using Microsoft.AspNetCore.Mvc;
using projetoalex.Api.response;
using projetoalex.Aplicacao;
using Projetoalex.Dominio.Entidades;
using projetoalex.Api.models.request;



namespace projeto360.Api
{
    [ApiController]
    [Route("[controller]")]

    public class ProdutoController : ControllerBase
    {
        private readonly IProdutosAplicacao _produtosAplicacao;

        public ProdutoController(IProdutosAplicacao produtosAplicacao)
        {
            _produtosAplicacao = produtosAplicacao;
        }

        [HttpGet]
        [Route("Obter/{produtoId}")]
        public async Task<ActionResult> Obter([FromRoute] int produtoId, [FromQuery] bool ativo)
        {
            try
            {
                var produtoDominio = await _produtosAplicacao.Obter(produtoId, ativo);

                var produtoResponse = new ProdutoResponse()
                {
                    Id = produtoDominio.Id,
                    Nome = produtoDominio.Nome,
                    Preco = produtoDominio.Preco,
                    Descricao = produtoDominio.Descricao

                };

                return Ok(produtoDominio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] ProdutoCriar produtoCriar)
        {
            try
            {
                var produtoDominio = new Produtos()
                {
                    Nome = produtoCriar.Nome,
                    Preco = produtoCriar.Preco,
                    Descricao = produtoCriar.Descricao

                };

                var usuarioId = await _produtosAplicacao.Criar(produtoDominio);

                return Ok(usuarioId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] ProdutoAtualizar produtoAtualizar)
        {
            try
            {
                var produtoDominio = new Produtos()
                {
                    Id = produtoAtualizar.Id,
                    Nome = produtoAtualizar.Nome,
                    Preco = produtoAtualizar.Preco,
                    Descricao = produtoAtualizar.Descricao



                };

                await _produtosAplicacao.Atualizar(produtoDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpDelete]
        [Route("Deletar/{produtoId}")]
        public async Task<ActionResult> Deletar([FromRoute] int produtoId)
        {
            try
            {
                await _produtosAplicacao.Deletar(produtoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Restaurar/{produtoId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int produtoId)
        {
            try
            {
                await _produtosAplicacao.Restaurar(produtoId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> List([FromQuery] bool ativos)
        {
            try
            {
                var usuariosDominio = await _produtosAplicacao.Listar(ativos);

                var usuarios = usuariosDominio.Select(usuario => new ProdutoResponse()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Preco = usuario.Preco,
                    Descricao = usuario.Descricao

                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}