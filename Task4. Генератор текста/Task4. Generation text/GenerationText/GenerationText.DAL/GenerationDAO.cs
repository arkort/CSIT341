using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerationText.DAL
{
    public class GenerationDAO : IGenerationDAO
    {
        private static IDictionary<string, List<string>> resul;
        private static string book;

        public GenerationDAO()
        {
            resul = this.GetWords();
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
            book.Insert(book.Length, string.Join(" ", text));
            if (!resul.ContainsKey(text[0].ToLower()))
            {
                resul.Add(text[0].ToLower(), new List<string>());
            }

            for (int i = 0; i < text.Count - 1; i++)
            {
                if (!resul.ContainsKey(text[i + 1].ToLower()))
                {
                    var tempList = new List<string>();
                    tempList.Add(text[i].ToLower());
                    resul.Add(text[i + 1].ToLower(), tempList);
                    if (!resul.ContainsKey(text[i].ToLower()))
                    {
                        resul.Add(text[i].ToLower(), new List<string>());
                    }
                }
                else
                {
                    if (!resul[text[i + 1].ToLower()].Contains(text[i].ToLower()))
                    {
                        resul[text[i + 1].ToLower()].Add(text[i].ToLower());
                    }
                }
            }

            if (!resul.ContainsKey(text.Last().ToLower()))
            {
                resul.Add(text.Last().ToLower(), new List<string>());
            }
        }

        public void AddWords(List<string> text, string newbook)
        {
            text = text.Select(word => this.ClearWord(word)).ToList();
            if (!resul.ContainsKey(text[0].ToLower()))
            {
                resul.Add(text[0].ToLower(), new List<string>());
            }

            for (int i = 0; i < text.Count - 1; i++)
            {
                if (!resul.ContainsKey(text[i + 1].ToLower()))
                {
                    var tempList = new List<string>();
                    tempList.Add(text[i].ToLower());
                    resul.Add(text[i + 1].ToLower(), tempList);
                    if (!resul.ContainsKey(text[i].ToLower()))
                    {
                        resul.Add(text[i].ToLower(), new List<string>());
                    }
                }
                else
                {
                    if (!resul[text[i + 1].ToLower()].Contains(text[i].ToLower()))
                    {
                        resul[text[i + 1].ToLower()].Add(text[i].ToLower());
                    }
                }
            }

            if (!resul.ContainsKey(text.Last().ToLower()))
            {
                resul.Add(text.Last().ToLower(), new List<string>());
            }

            this.SaveWords(text);
        }

        public void AddText(string text)
        {
            book = text;
        }

        public IDictionary<string, List<string>> Getwords()
        {
            return new Dictionary<string, List<string>>(resul);
        }

        public string ClearWord(string temp)
        {
            string outs = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                if (!char.IsControl(temp[i]))
                {
                    outs += temp[i];
                }
            }

            return outs.Trim(' ');
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

        private void SaveWords(List<string> text)
        {
            using (StreamWriter output = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputWords.txt"), true))
            {
                output.WriteLine(string.Join(" ", text));
            }
        }

        private Dictionary<string, List<string>> GetWords()
        {
            if (!File.Exists("inputWords.txt"))
            {
                File.Create("inputWords.txt");
            }

            var result1 = new Dictionary<string, List<string>>();
            using (StreamReader input = new StreamReader("inputWords.txt"))
            {
                if (!input.EndOfStream)
                {
                    book = input.ReadToEnd();

                    if (book != string.Empty)
                    {
                        var text = book.Split(' ').ToList();
                        if (!result1.ContainsKey(text[0].ToLower()))
                        {
                            result1.Add(text[0].ToLower(), new List<string>());
                        }

                        for (int i = 0; i < text.Count - 1; i++)
                        {
                            if (!result1.ContainsKey(text[i + 1].ToLower()))
                            {
                                var tempList = new List<string>();
                                tempList.Add(text[i].ToLower());
                                result1.Add(text[i + 1].ToLower(), tempList);
                                if (!result1.ContainsKey(text[i].ToLower()))
                                {
                                    result1.Add(text[i].ToLower(), new List<string>());
                                }
                            }
                            else
                            {
                                if (!result1[text[i + 1].ToLower()].Contains(text[i].ToLower()))
                                {
                                    result1[text[i + 1].ToLower()].Add(text[i].ToLower());
                                }
                            }
                        }

                        if (!result1.ContainsKey(text.Last().ToLower()))
                        {
                            result1.Add(text.Last().ToLower(), new List<string>());
                        }
                    }
                }
            }

            return result1;
        }
    }
}