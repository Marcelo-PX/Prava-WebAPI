using API.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {
        private readonly DataContext _context;
        public FolhaController(DataContext context) =>
            _context = context;

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar(){

            var folhas = _context.Folhas.ToList();
            var funcionarios = _context.Funcionarios.ToList();

            for(int i = 0; i < folhas.Count; i++){
                
                folhas[i].CpfFuncionario = funcionarios.
                    FirstOrDefault(f => f.Cpf == funcionarios[i].Cpf).Cpf;
                folhas[i].NomeFuncionario = funcionarios.
                    FirstOrDefault(f => f.Cpf == funcionarios[i].Nome).Nome;
            }

            return Ok(folhas);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {
            Funcionario funcionario = _context.Funcionarios.
                FirstOrDefault(f => f.Cpf.Equals(folha.CpfFuncionario));

            if (funcionario != null)
            {
                folha.CpfFuncionario = funcionario.Cpf;
                folha.NomeFuncionario = funcionario.Nome;

                _context.Folhas.Add(folha);
                _context.SaveChanges();

                return Created("", folha);
            }

            return NotFound();
        }
        
        [HttpGet]
        [Route("buscar/{Cpf}")]
        public IActionResult BuscarCpf([FromRoute] string Cpf)
        {  
            FolhaPagamento folha = _context.Folhas.
                FirstOrDefault(f => f.CpfFuncionario.Equals(Cpf));

            return folha != null ? Ok(folha) : NotFound();
        }

        [HttpGet]
        [Route("buscar/{mes}")]
        public IActionResult BuscarMes([FromRoute] string Mes)
        {  
            FolhaPagamento folha = _context.Folhas.
                FirstOrDefault(f => f.Mes.Equals(Mes));

            return folha != null ? Ok(folha) : NotFound();
        }

        [HttpGet]
        [Route("buscar/{ano}")]
        public IActionResult BuscarAno([FromRoute] string Ano)
        {  
            FolhaPagamento folha = _context.Folhas.
                FirstOrDefault(f => f.Ano.Equals(Ano));

            return folha != null ? Ok(folha) : NotFound();
        }
        
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            FolhaPagamento folha = _context.Folhas.Find(id);
            if (folha != null)
            {
                _context.Folhas.Remove(folha);
                _context.SaveChanges();
                return Ok(folha);
            }
            return NotFound();
        }

        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] FolhaPagamento folha)
        {
            try
            {
                _context.Folhas.Update(folha);
                _context.SaveChanges();
                return Ok(folha);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}