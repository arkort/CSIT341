using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationText.DAL.Interface
{
    public interface IGenerationDAO
    {
        IDictionary<string, List<string>> GetWords();
    }
}
