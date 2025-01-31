
using Microsoft.AspNetCore.Mvc;
using projetoalex.Api.response;
using projetoalex.Aplicacao;
using Projetoalex.Dominio.Entidades;
using projetoalex.Api.models.request;



namespace projeto360.Api
{
    [ApiController]
    [Route("[controller]")]

    public class usuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public usuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> Obter([FromRoute] int usuarioId, [FromQuery] bool ativo)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.Obter(usuarioId, ativo);

                var usuarioResposta = new UsuarioResponse()
                {
                    Id = usuarioDominio.Id,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,

                };

                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Criar([FromBody] UsuarioCriar usuarioCriar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha,
                    TipoUsuario = usuarioCriar.Tipo

                };

                var usuarioId = await _usuarioAplicacao.Criar(usuarioDominio);

                return Ok(usuarioId);
            }
            catch (Exception ex)
            {
                return BadRequest( $"Erro ao criar {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] UsuarioAtualizar usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email

                };

                await _usuarioAplicacao.Atualizar(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao Atualizar: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("AtualizarSenha")]
        public async Task<ActionResult> AtualizarSenha([FromBody] UsuarioAtualizarSenha usuario)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuario.Id,
                    Senha = usuario.Senha
                };

                await _usuarioAplicacao.AtualizarSenha(usuarioDominio, usuario.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Logar")]
        public async Task<ActionResult> ObterSenhaEmail([FromBody] UsuarioLogar usuarioLogar)
        {

            var usuario = await _usuarioAplicacao.ObterSenhaEmail(usuarioLogar.Email, usuarioLogar.Senha);

            if (usuario != null)
            {
                //Retorna sucesso e os dados do usuário(ou um token JWT, caso esteja usando autenticação por token)
                return Ok(new { success = true, message = "Login bem-sucedido", usuarioId = usuario.Id, tipoUsuario = usuario.TipoUsuario });
            }
            else
            {

                return Unauthorized(new { success = false, message = "Email ou senha incorretos" });
            }

        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> Deletar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.Deletar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public async Task<ActionResult> Restaurar([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.Restaurar(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> List([FromQuery] bool ativos)
        {
            try
            {
                var usuariosDominio = await _usuarioAplicacao.Listar(ativos);

                var usuarios = usuariosDominio.Select(usuario => new UsuarioResponse()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,

                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar: {ex.Message}");
            }
        }



    }
}