using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerationTextMarcov.DAL
{
    public class GenerationDAOMarkov
    {
        private static string words;

        public GenerationDAOMarkov()
        {
            words = this.GetWords();
        }

        public void AddWords(string path)
        {
            var text = new List<string>();

            using (StreamReader input = new StreamReader(path))
            {
                var temptext = input.ReadToEnd();
                var separator = this.GetSeparator(temptext);

                text = temptext.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                text = text.Select(word => this.ClearWord(word)).ToList();
            }
            var result = new StringBuilder();
            foreach (var item in text)
            {
                result.AppendFormat($"{item }");
            }
            words += result.ToString();

            this.SaveWords();
        }

        public void AddWords(List<string> text)
        {
            text = text.Select(word => this.ClearWord(word)).ToList();

            if (!words.ContainsKey(text[0].ToLower()))
            {
                words.Add(text[0].ToLower(), new List<string>());
            }

            for (int i = 0; i < text.Count - 1; i++)
            {
                if (!words.ContainsKey(text[i + 1].ToLower()))
                {
                    var tempList = new List<string>();
                    tempList.Add(text[i].ToLower());
                    words.Add(text[i + 1].ToLower(), tempList);
                    if (!words.ContainsKey(text[i].ToLower()))
                    {
                        words.Add(text[i].ToLower(), new List<string>());
                    }
                }
                else
                {
                    if (!words[text[i + 1].ToLower()].Contains(text[i].ToLower()))
                    {
                        words[text[i + 1].ToLower()].Add(text[i].ToLower());
                    }
                }
            }

            if (!words.ContainsKey(text.Last().ToLower()))
            {
                words.Add(text.Last().ToLower(), new List<string>());
            }

            this.SaveWords();
        }

        public string Getwords()
        {
            return words.ToString();
        }

        public string ClearWord(string temp)
        {
            string outs = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (!Char.IsControl(temp[i]))
                {
                    outs += temp[i];
                }
            }
            return outs.Trim(' ');
        }

        private string GetWords()
        {
            if (!File.Exists("inputMarcov.txt"))
            {
                File.Create("inputMarcov.txt");
            }

            var result = string.Empty;
            using (StreamReader input = new StreamReader("inputWords.txt"))
            {
                result = input.ReadToEnd();
            }

            return result;
        }

        public List<string> GetSeparator(string text)
        {
            var separator = new List<string>();
            foreach (var tempChar in text)
            {
                if ((char.IsSeparator(tempChar) || char.IsPunctuation(tempChar)) && !separator.Contains(tempChar.ToString()))
                {
                    separator.Add(tempChar.ToString());
                }
            }

            return separator;
        }

        private void SaveWords()
        {
            using (StreamWriter output = new StreamWriter("inputWords.txt"))
            {
                output.WriteLine(words);
            }
        }
    }
}
}
}