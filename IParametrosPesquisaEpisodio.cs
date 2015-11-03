using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmosBatista.ComicsServer.Core
{
    // A interface apenas vai tratar os métodos para informar os parâmetros. 
    // Deve ser informado o parametro de tipo T, para informar o tipo exigido pela interface ICollection
    public interface IParametrosPesquisaEpisodio
    {
        // Função que adicionará um parâmetro
        void NovoParametro(string nome, string valor);

        // Função que retornará todos os parâmetros
        IDictionary<string,string> RetornarParametros();

    }
}