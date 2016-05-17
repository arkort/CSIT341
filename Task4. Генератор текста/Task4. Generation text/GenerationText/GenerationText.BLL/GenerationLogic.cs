using GenerationText.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerationText.BLL
{
    public class GenerationLogic : IGenerationLogic
    {
        private IGenerationDAO data = new GenerationDAO();
        private Random rand = new Random();

        public string GenerateRandom()
        {
            var words = data.Getwords();
            var word = words.ElementAt(rand.Next(1, words.Count)).Key;
            string result = string.Empty;
            int i = 0;
            this.DFS(word, rand.Next(1, 100), ref result, ref i);

            return result;
        }

        public List<string> GetWords()
        {
            var tempResult = new List<string>();
            var words = this.GenerateRandom().Split(' ').ToList();

            int count = 0;
            var tempString = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                if (count == 5)
                {
                    tempResult.Add(tempString.ToString());
                    count = 0;
                    tempString.Clear();
                }
                tempString.AppendFormat($"{words[i]} ");
                count++;
            }

            return tempResult;
        }

        public List<string> GetWords(int n)
        {
            var tempResult = new List<string>();
            var words = this.GenerateRandom(n).Split(' ').ToList();

            int count = 0;
            var tempString = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                if (count == 5)
                {
                    tempResult.Add(tempString.ToString());
                    count = 0;
                    tempString.Clear();
                }
                tempString.AppendFormat($"{words[i]} ");
                count++;
            }

            return tempResult;
        }

        public string GenerateRandom(int n)
        {
            var words = data.Getwords();
            var word = words.ElementAt(rand.Next(1, words.Count)).Key;
            string result = string.Empty;
            int i = 0;
            this.DFS(word, n, ref result, ref i);

            return result;
        }

        public void AddText(string text)
        {
            var separator = this.GetSeparator(text);
            var tempstring = text.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            this.data.AddWords(tempstring);
        }

        public void AddFile(string path)
        {
            using (StreamReader input = new StreamReader(path))
            {
                var text = input.ReadToEnd();
                var separator = this.GetSeparator(text);
                this.data.AddText(text);
                this.data.AddWords(text.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
            }
        }

        private void DFS(string start, int n, ref string result, ref int count)
        {
            if (count == n)
            {
                return;
            }
            result += " " + start;
            count++;
            var dictonary = this.data.Getwords()[start];
            this.DFS(dictonary[rand.Next(0, dictonary.Count)], n, ref result, ref count);
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
    }
}