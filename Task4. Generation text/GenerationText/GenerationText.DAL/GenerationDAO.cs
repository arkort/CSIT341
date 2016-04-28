using GenerationText.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationText.DAL
{
    public class GenerationDAO: IGenerationDAO
    {
        private static IDictionary<string,List<string>> words;
         
        static GenerationDAO()
        {
            words = new Dictionary<string, List<string>>();
        }

        private void ParseFile()
        {

        }

        public IDictionary<string,List<string>> GetWords()
        {
            return;
        }
    }
}
