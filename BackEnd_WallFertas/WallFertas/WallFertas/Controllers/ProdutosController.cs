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
    public class ProdutosController : ControllerBase
    {
        private IProdutosRepository produtos { get; set; }

        public ProdutosController()
        {
            produtos = new ProdutosRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(produtos.Listar());
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
                return Ok(produtos.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Produtos novoProduto)
        {
            try
            {
                produtos.Cadastrar(novoProduto);
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
                produtos.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, Produtos novoProduto)
        {
            try
            {
                produtos.Atualizar(id, novoProduto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
