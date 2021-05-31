using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperInovacoes.Business.Interfaces;
using SuperInovacoes.Business.Models;
using SuperInovacoes.Data.Data;

namespace SuperInovacoes.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context) { }

        public async Task AdicionarProduto(Produto produto)
        {
             await Adicionar(produto);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await Atualizar(produto);
        }

        public Task<List<Produto>> ObterTodosProdutos()
        {
            return ObterTodos();
        }

        public async Task<bool> RemoverProduto(Guid id)
        {
            await Remover(id);
            return true;
        }
    }
}
