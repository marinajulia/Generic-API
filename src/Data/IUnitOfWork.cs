using EFCore.UowRepository.Data.Repositories;
using System;

namespace EFCore.UowRepository.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IDepartamentoRepository DepartamentoRepository { get; } 
    }
}
