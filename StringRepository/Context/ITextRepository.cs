using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmosBatista.ComicsServer.Core.StringRepository.Context
{
    // Interface that represents a text repository
    public interface ITextRepository <RepositoryType>
    {
        // The DOM Id element
        string DOMElementID {get; set;}

        // The List of possible translations of the element
        RepositoryType translations();

        // Function to add translation to the element
        void AddTranslation(IIdiomTranslation idiomTranslation);
    }
}
