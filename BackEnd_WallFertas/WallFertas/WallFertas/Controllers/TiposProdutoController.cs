using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;
using WallFertas.Interfaces;
using WallFertas.Repositories;

namespace WallFertas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposProdutoController : ControllerBase
    {
        private ITiposProdutoRepository tipoProduto { get; set; }

        public TiposProdutoController()
        {
            tipoProduto = new TiposProdutosRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(tipoProduto.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(tipoProduto.BuscarPorId(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(TiposProduto novoTipoProduto)
        {
            try
            {
                tipoProduto.Cadastrar(novoTipoProduto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            try
            {
                tipoProduto.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, TiposProduto novoTipoProduto)
        {
            try
            {
                tipoProduto.Atualizar(id, novoTipoProduto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
