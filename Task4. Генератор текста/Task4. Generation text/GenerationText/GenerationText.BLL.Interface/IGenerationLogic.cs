using System.Collections.Generic;

namespace GenerationText.BLL
{
    public interface IGenerationLogic
    {
        void AddFile(string path);

        void AddText(string text);

        string GenerateRandom();

        string GenerateRandom(int n);

        List<string> GetSeparator(string text);

        List<string> GetWords();

        List<string> GetWords(int n);
    }
}