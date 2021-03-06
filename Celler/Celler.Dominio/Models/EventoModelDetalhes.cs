﻿using Celler.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celler.Dominio.Models
{
    public class EventoModelDetalhes : AnuncioModelDetalhes
    {
        public DateTime DataRealizacao { get; set; }
        public string Local { get; set; }
        public DateTime DataMaximaConfirmacao { get; set; }
        public double ValorPorPessoa { get; set; }
        public List<UsuarioModel> Confirmados { get; set; }
        public int NumeroConfirmados { get; set; }

        public EventoModelDetalhes(Anuncio anuncio)
                                   : base(anuncio.Id,
                                          anuncio.Titulo,
                                          anuncio.Descricao,
                                          anuncio.DataAnuncio,
                                          anuncio.TipoAnuncio,
                                          anuncio.Foto1,
                                          anuncio.Foto2,
                                          anuncio.Foto3,
                                          new UsuarioModel (anuncio.Criador.Id, anuncio.Criador.Nome, anuncio.Criador.Email),
                                          anuncio.Status)
        { }

        public void SetarInformacoesEspecificas (Evento evento)
        {
            this.Local = evento.Local;
            this.ValorPorPessoa = evento.ValorPorPessoa;
            this.DataRealizacao = evento.DataRealizacao;
        }

        public void PopularConfirmados(Evento evento)
        {
            Confirmados = new List<UsuarioModel>();

            foreach (var confirmados in evento.Confirmados)
            {
                this.Confirmados.Add (new UsuarioModel(confirmados.Id,
                                                       confirmados.Nome,
                                                       confirmados.Email));
            }
            ContarConfirmados(evento);
        }

        public void ContarConfirmados(Evento evento)
        {
            if (Confirmados == null) { Confirmados = new List<UsuarioModel>(); }
            this.NumeroConfirmados = evento.Confirmados.Count;
        }
    }
}
