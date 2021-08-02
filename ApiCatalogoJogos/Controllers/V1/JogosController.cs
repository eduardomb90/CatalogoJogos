using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogos.Domain.InputModel;
using ApiCatalogoJogos.Domain.ViewModel;
using ApiCatalogoJogos.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Get(
            [FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
	        var jogos = await _jogoService.Get(pagina, quantidade);
	
	        if(jogos.Count() == 0)
		        return NoContent();

	        return Ok(jogos);
        }


        [HttpGet("id:guid")]
        public async Task<ActionResult<JogoViewModel>> GetById([FromRoute] Guid id)
        {
            var jogo = await _jogoService.GetById(id);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Post([FromBody] JogoInputModel jogoInput)
        {
            try
            {
                var jogo = await _jogoService.Post(jogoInput);
                
                return Ok(jogo);
            }
            catch (Exception)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }
    
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] JogoInputModel jogoInput)
        {
            try
            {
                await _jogoService.Update(id, jogoInput);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _jogoService.Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}
