﻿using System;
using System.Net;
using System.Text;

namespace Celler.Infraestrutura.Servicos
{
    public class EnviarMensagemSlack
    {
        public EnviarMensagemSlack(string usuario, string texto)
        {
            MandarMensagemNoSlack(usuario, texto);
        }

        public static void MandarMensagemNoSlack(string usuario, string texto)
        {
            byte[] data = Convert.FromBase64String("eG94cC0xNjY2ODQ0ODY5NjAtMTY3NzMwNzA0NTEyLTIwOTAyNjQxNDgyMi03OWM3ZTc3ZTYwYzRkZjY3YmIzZWMzN2M1OTY1MDNiYg==");
            string token = Encoding.UTF8.GetString(data);
            StringBuilder enviar = new StringBuilder();
            enviar.Append("https://slack.com/api/chat.postMessage?token=");
            enviar.Append(token);
            enviar.Append("&channel=");
            enviar.Append(Uri.EscapeDataString(usuario));
            enviar.Append("&text=");
            enviar.Append(Uri.EscapeDataString(texto));
            enviar.Append("&pretty=1");
            enviar.Append("&icon_url=https%3A%2F%2Fd30y9cdsu7xlg0.cloudfront.net%2Fpng%2F24572-200.png&username=Celler&pretty=1");
            String strenviar = enviar.ToString();
            WebRequest request = WebRequest.Create(strenviar);
            WebResponse response = request.GetResponse();
            Console.WriteLine(response);
            response.Close();
        }
    }
}
