using EFCore.UowRepository.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Domain;
using System.Threading.Tasks;

namespace EFCore.UowRepository.Data.Repositories
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
        //private readonly ApplicationContext _context;
        //private readonly DbSet<Departamento> _dbset;

        public DepartamentoRepository (ApplicationContext context) : base (context)
        {
            //_context = context;
            //_dbset = _context.Set<Departamento>();
        }
        //esses dois métodos comentados abaixo não são mais necessários pois existem no repositório genérico
        //public void Add(Departamento departamento)
        //{
        //    _dbset.Add(departamento);
        //}

        //public async Task<Departamento> GetByIdAsync(int id)
        //{
        //    return await _dbset
        //        .Include(p => p.Colaboradores)
        //        .FirstOrDefaultAsync(p => p.Id == id);
        //}

        //public bool Save()
        //{
        //    return _context.SaveChanges() > 0;
        //}
    }
}
