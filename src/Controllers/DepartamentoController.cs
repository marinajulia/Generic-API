using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.UowRepository.Data;
using EFCore.UowRepository.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.Domain;

namespace EFCore.UowRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly ILogger<DepartamentoController> _logger;
        private readonly IUnitOfWork _uow;
        //private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(ILogger<DepartamentoController> logger, IDepartamentoRepository repository, IUnitOfWork uow)
        {
            _logger = logger;
            //_departamentoRepository = repository;
            _uow = uow;
        }

        //a parte comentada (referente ao from services), é uma maneira para ser usada para recuperar o repositório sem a necessidade da injeção de dependencia
        //departamento/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id /*, [FromServices]IDepartemantoRepository repository*/)
        {
            //var departamento = await _departamentoRepository.GetByIdAsync(id);
            var departamento = await _uow.DepartamentoRepository.GetByIdAsync(id);

            return Ok(departamento);
        }
        [HttpPost]
        public IActionResult CreateDepartamento(Departamento departamento)
        {
             //_departamentoRepository.Add(departamento);
             _uow.DepartamentoRepository.Add(departamento);

            //var saved = _departamentoRepository.Save();

            _uow.Commit();
            return Ok(departamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDepartamentoAsync(int id)
        {
            var departamento = await _uow.DepartamentoRepository.GetByIdAsync(id);

            _uow.DepartamentoRepository.Remove(departamento);
            _uow.Commit();
            return Ok(departamento);
        }

        //departamento/?descricao=teste
        [HttpGet]
        public async Task<IActionResult> ConsultarDepartamentoAsync([FromQuery] string descricao)
        {
            var departamentos = await _uow.DepartamentoRepository.GetDataAsync(
                p=> p.Descricao.Contains(descricao),
                p=> p.Include(c=> c.Colaboradores),
                take: 2); //take para retornar apenas 2 registros

            
            return Ok(departamentos);
        }
    }
}
