using src.Data;

namespace EFCore.UowRepository.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        private IDepartamentoRepository _departamentoRepository;

        //essa é uma estratégia muito usada para não precisar manter na memória objetos que não estão sendo utilizados no momento
        //o ponto negativo seria que teria que duplicar esse código para cada repositório
        public IDepartamentoRepository DepartamentoRepository
        {
            get => _departamentoRepository ?? (_departamentoRepository = new DepartamentoRepository(_context));
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
