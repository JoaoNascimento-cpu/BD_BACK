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
    public class EmpresasController : ControllerBase
    {
        private IEmpresasRepository empresas { get; set; }

        public EmpresasController()
        {
            empresas = new EmpresasRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(empresas.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(empresas.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Empresas novaEmpresa)
        {
            try
            {
                empresas.Cadastrar(novaEmpresa);
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
                empresas.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, Empresas novaEmpresa)
        {
            try
            {
                empresas.Atualizar(id, novaEmpresa);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
