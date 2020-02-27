using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controller
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]


    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository _funcionariosRepositoy { get; set;  }

        public FuncionariosController()
        {
            _funcionariosRepositoy = new FuncionariosRepository();
        }
       
        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            return _funcionariosRepositoy.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain funcionario)
        {
            _funcionariosRepositoy.Inserir(funcionario);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionariosDomain funcionarioBuscar = _funcionariosRepositoy.BuscarPorId(id);

            if(funcionarioBuscar == null)
            {
                return NotFound("Nenhum funcionario foi encontrado");
            }

            return Ok(funcionarioBuscar);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, FuncionariosDomain funcionarios)
        {

            // Erro : Esta passando o Id mas nao esta pegando o nome e sobrenome 
            FuncionariosDomain updateFuncionario = _funcionariosRepositoy.BuscarPorId(id);

            if (updateFuncionario == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _funcionariosRepositoy.AtulizarIdUrl(id, funcionarios);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionariosRepositoy.Deletar(id);

            return Ok("Funcionario Deletado");
        }
    }
}
