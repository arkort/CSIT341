using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenerationText.BLL;
using GenerationText.DAL;
using GenerationTextMarkov.BLL.Interface;

namespace GenerationTextMarvoc.BLL
{
    public class GenMarkovText : IGenMarkovText
    {
        private static Random genNum = new Random();
        private IGenerationDAO data = Common.Data;
        private Dictionary<List<string>, Dictionary<string, double>> prob = new Dictionary<List<string>, Dictionary<string, double>>(0);
        private int k = 2, n = 10;
        private int precCoeff = 50;

        public List<string> GetWords(int countWords)
        {
            this.n = Math.Max(countWords, 3);
            var tempResult = new List<string>();
            var words = this.GenerateText().Split(' ').ToList();

            int count = 0;
            var tempString = new StringBuilder();
            for (int i = 0; i < countWords; i++)
            {
                tempString.AppendFormat($"{words[i]} ");
                count++;
                if (count == 5 || i == countWords - 1)
                {
                    tempResult.Add(tempString.ToString());
                    count = 0;
                    tempString.Clear();
                }
            }

            return tempResult;
        }

        private string GenerateText()
        {
            string res = string.Empty;
            this.Analyze(this.data.GetText());
            List<string> curKey = new List<string>(0);

            int cnt = 0;
            int end = genNum.Next(this.prob.Count);
            foreach (List<string> i in this.prob.Keys)
            {
                if (cnt == end)
                {
                    curKey = i;
                    break;
                }

                cnt++;
            }

            for (int i = 0; i < curKey.Count; i++)
            {
                res += curKey[i] + " ";
            }

            for (int i = 0; i < this.n - this.k; i++)
            {
                string temp = this.GetRandomWord(this.prob[curKey]);

                List<string> t = new List<string>(curKey);
                t.Add(temp);
                t.RemoveAt(0);
                curKey = t;

                foreach (List<string> j in this.prob.Keys)
                {
                    if (this.Cmp(curKey, j))
                    {
                        curKey = j;
                        break;
                    }
                }

                res += temp + " ";
            }

            return res;
        }

        private bool Cmp(List<string> a, List<string> b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        private string ClearWord(string temp)
        {
            string outs = string.Empty;
            for (int i = 0; i < temp.Length; i++)
            {
                if (char.IsLetter(temp[i]))
                {
                    outs += temp[i];
                }
            }

            return outs;
        }

        private void Analyze(string textfile)
        {
            Dictionary<List<string>, Dictionary<string, int>> freq = new Dictionary<List<string>, Dictionary<string, int>>(0);
            Dictionary<List<string>, int> count = new Dictionary<List<string>, int>(0);
            List<string> key = new List<string>(0);
            string temp;

            string[] text = textfile.Split(new char[] { ' ', '\n', '\r', '-' });
            if (text.Length == 0)
            {
                return;
            }

            int indText = 0;
            for (int i = 0; i < this.k && indText < text.Length; i++)
            {
                temp = this.ClearWord(text[indText].Trim(' '));
                if (temp.Length > 0)
                {
                    key.Add(temp.ToLower());
                }
                else
                {
                    i--;
                }

                indText++;
            }

            for (int i = indText; i < text.Length; i++)
            {
                temp = this.ClearWord(text[i].Trim(' '));
                if (temp.Length > 0)
                {
                    temp = temp.ToLower();

                    if (freq.ContainsKey(key))
                    {
                        if (freq[key].ContainsKey(temp))
                        {
                            freq[key][temp]++;
                        }
                        else
                        {
                            freq[key].Add(temp, 1);
                        }

                        count[key]++;
                    }
                    else
                    {
                        Dictionary<string, int> t = new Dictionary<string, int>(0);
                        t.Add(temp, 1);
                        List<string> l = new List<string>(key);
                        freq.Add(l, t);
                        count.Add(l, 1);
                    }

                    key.Add(temp);
                    key.RemoveAt(0);
                }
            }

            foreach (List<string> i in freq.Keys)
            {
                foreach (string j in freq[i].Keys)
                {
                    if (this.prob.ContainsKey(i))
                    {
                        if (this.prob[i].ContainsKey(j))
                        {
                            this.prob[i][j] = freq[i][j] / ((double)count[i]);
                        }
                        else
                        {
                            this.prob[i].Add(j, freq[i][j] / ((double)count[i]));
                        }
                    }
                    else
                    {
                        Dictionary<string, double> t = new Dictionary<string, double>();
                        t.Add(j, freq[i][j] / ((double)count[i]));
                        this.prob.Add(i, t);
                    }
                }
            }
        }

        private string GetRandomWord(Dictionary<string, double> wordtable)
        {
            List<string> words = new List<string>(0);

            foreach (string i in wordtable.Keys)
            {
                for (int j = 0; j < this.precCoeff * wordtable[i]; j++)
                {
                    words.Add(i);
                }
            }

            if (words.Capacity == 0)
            {
                return null;
            }

            return words[genNum.Next(words.Count)];
        }
    }
}