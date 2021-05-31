using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SuperInovacoes.Business.Models;

namespace SuperInovacoes.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<int> SaveChanges();
    }
}
