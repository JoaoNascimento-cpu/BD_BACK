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
        //[Authorize(Roles = "1")]
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
        //[Authorize(Roles = "1")]
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
        //[Authorize(Roles = "1")]
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

        [HttpPost("imagem")]
        public IActionResult UploadFoto([FromForm] string request)
        {
            try
            {
                // variavel "arquivo" igual a uma execução de uma requisição de um formulário que inclui os arquivos junto
                var arquivo = Request.Form.Files[0];

                // variavel "nomeArquivo" é igual ao nome do arquivo de uma requisição de arquivos
                var nomeArquivo = arquivo.FileName;
                // string "extensao" é igual a extensão do arquivo
                string extensao = nomeArquivo.Split('.')[1].Trim();

                // caso a extensão seja desses tipos...
                if (extensao == "jpg" || extensao == "png" || extensao == "webp" || extensao == "jpeg" || extensao == "svg" || extensao == "jfif" || extensao == "tiff")
                {
                    // uma variavel "upload" será igual ao método de upload do repository com as informações tragas
                    var upload = produtos.UploadFoto(arquivo, "Imagens");
                    // e retorna o "upload"
                    return Ok(upload);
                }
                // caso contrário, retorna uma mensagem de erro
                return BadRequest("Formato não aceito!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
