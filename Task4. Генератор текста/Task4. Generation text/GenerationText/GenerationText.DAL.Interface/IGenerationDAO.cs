using System.Collections.Generic;

namespace GenerationText.DAL
{
    public interface IGenerationDAO
    {
        void AddWords(string path);

        void AddText(string text);

        void AddWords(List<string> text);

        string ClearWord(string temp);

        List<string> GetSeparator(string text);

        IDictionary<string, List<string>> Getwords();

        string GetText();
    }
}