using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperInovacoes.Business.Models;

namespace SuperInovacoes.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task<IEnumerable<Produto>> ObterTodosProdutos();
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Remover(Guid id);
    }
}
