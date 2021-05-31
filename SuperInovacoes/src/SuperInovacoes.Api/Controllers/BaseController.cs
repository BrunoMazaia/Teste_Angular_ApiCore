using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperInovacoes.Business.Interfaces;
using SuperInovacoes.Business.Notificacoes;

namespace SuperInovacoes.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {

        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }



    }
}
