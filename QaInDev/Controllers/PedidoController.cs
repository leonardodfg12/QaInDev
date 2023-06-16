using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QaInDev.Data;
using QaInDev.Models;
using Microsoft.AspNetCore.Http;

namespace QaInDev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            return Ok(_pedidoRepository.ObterTodos());
        }

        [HttpGet("por-cliente/{clienteId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Pedido>> GetPorClienteId(int clienteId)
        {
            return Ok(_pedidoRepository.ObterPorCliente(clienteId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            if (VerificarSePedidoJaExiste(pedido))
            {
                return Conflict(0);
            }
            var validacoesPedido = pedido.Validar();
            if (validacoesPedido.Any())
            {
                return BadRequest(validacoesPedido);
            }
            _pedidoRepository.Inserir(pedido);
            return CreatedAtAction(nameof(Post), pedido);
        }

        private bool VerificarSePedidoJaExiste(Pedido pedido)
        {
            return pedido.Id > 0 && _pedidoRepository.ObterPorId(pedido.Id) != null;
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if (id == default) return BadRequest("Idendificador inválido");
            if (id != pedido.Id) return BadRequest("Id diverge do solicitado");
            var pedidoBanco = _pedidoRepository.ObterPorId(id);
            if (pedidoBanco is null) return NotFound($"Pedido com ID {id} não localizado");
            pedidoBanco.DataPedido = pedido.DataPedido;
            pedidoBanco.ValorTotal = pedido.ValorTotal;
            var validacoesPedido = pedidoBanco.Validar();
            if (validacoesPedido.Any())
            {
                return BadRequest(validacoesPedido);
            }
            _pedidoRepository.Atualizar(pedido);
            return Ok(pedido);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            if (id == default) return BadRequest("Idendificador inválido");
            var pedidoBanco = _pedidoRepository.ObterPorId(id);
            if (pedidoBanco is null) return NotFound($"Pedido com ID {id} não localizado");
            _pedidoRepository.Deletar(pedidoBanco);
            return NoContent();
        }
    }
}