using System;
using AutoMapper;
using SuperInovacoes.Api.ViewModel;
using SuperInovacoes.Business.Models;

namespace SuperInovacoes.Api.Configuracao
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}
