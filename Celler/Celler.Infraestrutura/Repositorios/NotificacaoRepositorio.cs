﻿using Celler.Dominio.Entidades;
using System.Linq;
using System.Data.Entity;

namespace Celler.Infraestrutura.Repositorios
{
    public class NotificacaoRepositorio
    {
        readonly Contexto _contexto;

        public NotificacaoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public dynamic ObterNotificacoes(Usuario usuario)
        {
            return _contexto.Notificacao
                            .Include(x => x.Usuario)
                            .Select(x => new { texto = x.Texto,
                                               link = x.Link,
                                               status = x.Status});
        }

        public void CriarNotificacao(Notificacao notificacao)
        {
            _contexto.Notificacao.Add(notificacao);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}