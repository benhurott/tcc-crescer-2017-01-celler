﻿using Celler.Api.App_Start;
using Celler.Api.Models;
using Celler.Dominio.Entidades;
using Celler.Dominio.Models;
using Celler.Infraestrutura;
using Celler.Infraestrutura.Repositorios;
using Celler.Infraestrutura.Servicos;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Celler.Api.Controllers
{
    [BasicAuthorization]
    [RoutePrefix("api/evento")]

    public class EventoController : ControllerBasica
    {
        readonly EventoRepositorio _eventoRepositorio;
        readonly UsuarioRepositorio _usuarioRepositorio;
        readonly Contexto _contexto = new Contexto();

        public EventoController()
        {
            _usuarioRepositorio = new UsuarioRepositorio(_contexto);
            _eventoRepositorio = new EventoRepositorio(_contexto);
        }

        [HttpPost, Route("participar")]
        public HttpResponseMessage SalvarParticipanteEvento([FromBody] ParticiparEventoModel model)
        {
            var usuario = _usuarioRepositorio.ObterPorId(model.IdUsuario);
            var evento = _eventoRepositorio.ObterPorId(model.IdEvento);

            if (usuario == null || evento == null)
            {
                return ResponderErro("Usuario ou Evento inválidos.");
            }

            var usuarioLogado = _usuarioRepositorio.Obter(Thread.CurrentPrincipal.Identity.Name);

            evento.AdicionarInteressado(usuarioLogado);

            if (evento.Validar())
            {
                Notificar notificar = new Notificar(usuario, evento, evento.Criador, new NotificacaoRepositorio(_contexto));
                notificar.NotificarUsuarioEvento();
                _eventoRepositorio.Alterar(evento);
                _contexto.SaveChanges();
                return ResponderOk(new { texto = "Interesse salvo com sucesso" });
            }
            else
            {
                return ResponderErro(evento.Mensagens);
            }
        }

        [HttpPost, Route("desistir")]
        public HttpResponseMessage DeletarParticipanteEvento([FromBody] ParticiparEventoModel model)
        {
            var usuario = _usuarioRepositorio.ObterPorId(model.IdUsuario);
            var evento = _eventoRepositorio.ObterPorId(model.IdEvento);

            if (usuario == null || evento == null)
            {
                return ResponderErro("Usuario ou Evento inválidos.");
            }

            var usuarioLogado = _usuarioRepositorio.Obter(Thread.CurrentPrincipal.Identity.Name);

            if (usuarioLogado.Equals(evento.Criador))
            {
                return ResponderErro("Você não pode manifestar interesse no próprio anúncio.");
            }

            evento.RemoverInteressado(usuarioLogado);

            if (evento.Validar())
            {
                Notificar notificar = new Notificar(usuario, evento, evento.Criador, new NotificacaoRepositorio(_contexto));
                notificar.NotificarUsuarioDesistirEvento();
                _eventoRepositorio.Alterar(evento);
                _contexto.SaveChanges();
                return ResponderOk(new { texto = "Interesse salvo com sucesso" });
            }
            else
            {
                return ResponderErro(evento.Mensagens);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _usuarioRepositorio.Dispose();
                _eventoRepositorio.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
