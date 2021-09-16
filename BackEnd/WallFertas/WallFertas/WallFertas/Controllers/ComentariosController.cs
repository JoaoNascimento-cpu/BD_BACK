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
    public class ComentariosController : ControllerBase
    {
        private IComentariosRepository comentariosRepository { get; set; }
        public ComentariosController()
        {
            comentariosRepository = new ComentariosRepository();
        }

        //Listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(comentariosRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Buscar Por Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(comentariosRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //Cadastrar
        [HttpPost]
        public IActionResult Post(Comentarios novoComentario)
        {
            try
            {
                comentariosRepository.Cadastrar(novoComentario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(int id, Comentarios comentarioAtualizado)
        {
            try
            {
                comentariosRepository.Atualizar(id, comentarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                comentariosRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
