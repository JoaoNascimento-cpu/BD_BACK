using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


    }
}
