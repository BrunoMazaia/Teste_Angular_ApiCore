using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperInovacoes.Business.Interfaces;
using SuperInovacoes.Business.Models;
using SuperInovacoes.Business.Models.Validations;

namespace SuperInovacoes.Business.Services
{
    public class ProdutoService: BaseService ,IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository
            ,INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }


        public async Task<bool> Adicionar(Produto produto)
        {

            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            await _produtoRepository.Adicionar(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            var obj = await _produtoRepository.ObterTodos();
            return obj;
        }

        public async Task<bool> Remover(Guid id)
        {
           
            await _produtoRepository.Remover(id);
            return true;
        }
    }
}
