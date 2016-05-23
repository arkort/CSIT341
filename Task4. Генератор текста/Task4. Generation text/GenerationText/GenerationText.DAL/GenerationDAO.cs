using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerationText.DAL
{
    public class GenerationDAO : IGenerationDAO
    {
        private static IDictionary<string, List<string>> words;
        private static string book;

        public GenerationDAO()
        {
            words = this.GetWords();
            book = this.GetText();
        }

        public void AddWords(string path)
        {
            var text = new List<string>();

            using (StreamReader input = new StreamReader(path))
            {
                var temptext = input.ReadToEnd();
                var separator = this.GetSeparator(temptext);

                text = temptext.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }
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

        public void AddText(string text)
        {
            book = text;
        }

        public IDictionary<string, List<string>> Getwords()
        {
            return new Dictionary<string, List<string>>(words);
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

        private Dictionary<string, List<string>> GetWords()
        {
            if (!File.Exists("inputWords.txt"))
            {
                File.Create("inputWords.txt");
            }

            var result = new Dictionary<string, List<string>>();
            using (StreamReader input = new StreamReader("inputWords.txt"))
            {
                book = input.ReadToEnd();
                var tempstringArray = book.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in tempstringArray)
                {
                    var tempstring = item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(word => this.ClearWord(word)).ToList();

                    if (tempstring.Count != 0 && tempstring[0] != string.Empty)
                        result.Add(tempstring[0], tempstring.Skip(1).ToList());
                }
            }

            return result;
        }

        public string GetText()
        {
            return book;
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
                foreach (var word in words)
                {
                    output.WriteLine($"{word.Key.Trim(' ')} {string.Join(" ", word.Value.ToArray())}|");
                }
            }
        }
    }
}