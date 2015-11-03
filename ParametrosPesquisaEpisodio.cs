using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmosBatista.ComicsServer.Core
{
    public class ParametrosPesquisaEpisodio : IParametrosPesquisaEpisodio
    {
        private  Dictionary<string,string> Parametros;

        public ParametrosPesquisaEpisodio()
        {
            Parametros = new Dictionary<string,string>();
        }
        public void NovoParametro(string nome, string valor)
        {
            Parametros.Add(nome, valor);
        }

        public IDictionary<string, string> RetornarParametros()
        {
            return Parametros;
        }
        
    }
}
