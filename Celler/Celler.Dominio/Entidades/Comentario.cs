﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celler.Dominio.Entidades
{
    public class Comentario : EntidadeBasica
    {
        public int Id { get; private set; }
        public string Texto { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataComentario { get; private set; }

        protected Comentario() { }

        public Comentario(string texto, Usuario usuario)
        {
            Texto = texto;
            Usuario = usuario;
            DataComentario = DateTime.Now;

            if (string.IsNullOrWhiteSpace(texto))
                AdicionarMensagem("Comentário não pode ser em branco.");

        }
    }
}
