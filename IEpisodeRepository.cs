using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmosBatista.ComicsServer.Core
{
    public interface IEpisodeRepository
    {
        /*Modelo da classe:
         Como eu não sei como vou consultar os episódios (caso for só pelo número, ou só pelo ID, ou número ou idioma, 
         * devo implementar uma classe chamada ParametrosPesquisaEpisodio*/
        // Função que receberá um objeto do tipo paramentro, e o seu tipo e retornará um episódio.
        IEpisode Buscar(IParametrosPesquisaEpisodio parametrosPesquisa);

        // Função que receberá um episódio e fará o salvamento dele
        void Salvar(IEpisode episodio);
    }
}