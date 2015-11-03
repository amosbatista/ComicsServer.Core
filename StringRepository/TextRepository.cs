using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmosBatista.ComicsServer.Core.StringRepository
{
    public class TextRepository:ITextRepository<Dictionary<string,string>>
    {
        public string DOMElementID {get; set;}
        private Dictionary<string, string> idiomList = new Dictionary<string, string>();

        public void AddTranslation(IIdiomTranslation idiomTranslation)
        {
            idiomList.Add(idiomTranslation.IdiomName, idiomTranslation.Translation);
        }

        public Dictionary<string,string> translations(){
            return idiomList;
        }
    }
}
