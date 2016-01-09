using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmosBatista.ComicsServer.Core.StringRepository.Context
{
    // Class that have an idiom name and its respective translation
    public interface IIdiomTranslation
    {
        string IdiomName { get; set; }
        string Translation { get; set; }
    }
}
