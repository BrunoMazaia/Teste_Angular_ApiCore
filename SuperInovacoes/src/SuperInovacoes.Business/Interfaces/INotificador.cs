using System;
using System.Collections.Generic;
using SuperInovacoes.Business.Notificacoes;

namespace SuperInovacoes.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);

    }
}
