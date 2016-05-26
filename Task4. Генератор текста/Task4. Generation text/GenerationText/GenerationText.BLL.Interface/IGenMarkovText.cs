using System.Collections.Generic;

namespace GenerationTextMarkov.BLL.Interface
{
    public interface IGenMarkovText
    {
        List<string> GetWords(int countWords);
    }
}