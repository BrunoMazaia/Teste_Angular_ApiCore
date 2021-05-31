using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperInovacoes.Api.ViewModel;
using SuperInovacoes.Business.Interfaces;
using SuperInovacoes.Business.Models;

namespace SuperInovacoes.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService
            , IMapper mapper
            , INotificador notificador) : base(notificador)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorno todos os produtos da base
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterTodosProdutos")]
        public async Task<IEnumerable<ProdutoViewModel>> ProdutoViewModel()
        {
            try
            {
                var produto = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodosProdutos());
                return produto;
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message.ToString());
                return null;
            }
           
        }


        /// <summary>
        /// Crio novo produto com upload de imagem
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost("NovoProduto")]
        public async Task<ActionResult> Novo(ProdutoViewModel produto)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var imagemNome = Guid.NewGuid() + "_" + produto.Imagem;

                if (!UploadImagem(produto.ImagemUpload, imagemNome))
                {
                    return CustomResponse(produto);
                }

                produto.Imagem = imagemNome;

                await _produtoService.Adicionar(_mapper.Map<Produto>(produto));

                return CustomResponse(produto);
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message.ToString());
                return BadRequest();
            }

           
        }

        /// <summary>
        /// Atualizo produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPut("AtualizarProduto{id}")]
        public async Task<ActionResult> Atualizar(Guid id, ProdutoViewModel produto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                await _produtoService.Atualizar(_mapper.Map<Produto>(produto));

                return CustomResponse(produto);
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message.ToString());
                return BadRequest();
            }
           
        }

        /// <summary>
        /// Deleto produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeletarProduto{id}")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            try
            {
                var IsSucess = await _produtoService.Remover(id);
                if (IsSucess == true) return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message.ToString());
                return BadRequest();
            }
           
                 
        }

        /// <summary>
        /// monto a imagem em base 64
        /// </summary>
        /// <param name="imagem"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        private bool UploadImagem(string imagem, string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(imagem))
                {
                    NotificarErro("Nenhuma imagem selecionada");
                    return false;
                }

                var imageDataByteArray = Convert.FromBase64String(imagem);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nome);


                System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

                return true;
            }
            catch (Exception ex)
            {
              NotificarErro(ex.Message.ToString());
                return false;
            }
           
        }
    }
}
