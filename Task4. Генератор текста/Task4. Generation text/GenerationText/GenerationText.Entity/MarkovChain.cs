using System;
using System.Collections.Generic;
using System.IO;

namespace GenerationText.Entity
{
    public class MarkovChain
    {
        public Dictionary<List<string>, Dictionary<string, double>> Prob = new Dictionary<List<string>, Dictionary<string, double>>(0);
        public static Random genNum = new Random();
        public int K = 2, N = 10;
        private int PrecCoeff = 50;
        public bool possible = true;

        public string GenerateText(string fileName)
        {
            string res = "";
            Analyze(fileName);
            List<string> CurKey = new List<string>(0);

            int cnt = 0;
            int end = MarkovChain.genNum.Next(Prob.Count);
            foreach (List<string> i in Prob.Keys)
            {
                if (cnt == end)
                {
                    CurKey = i;
                    break;
                }
                cnt++;
            }

            for (int i = 0; i < CurKey.Count; i++)
            {
                res += CurKey[i] + " ";
            }
            for (int i = 0; i < N - K; i++)
            {
                string temp = GetRandomWord(Prob[CurKey]);

                List<string> t = new List<string>(CurKey);
                t.Add(temp);
                t.RemoveAt(0);
                CurKey = t;

                foreach (List<string> j in Prob.Keys)
                {
                    if (Cmp(CurKey, j))
                    {
                        CurKey = j;
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
            string outs = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (Char.IsLetter(temp[i]))
                {
                    outs += temp[i];
                }
            }
            return outs;
        }

        private void Analyze(string fileName)
        {
            Dictionary<List<string>, Dictionary<string, int>> Freq = new Dictionary<List<string>, Dictionary<string, int>>(0);
            Dictionary<List<string>, int> Count = new Dictionary<List<string>, int>(0);
            List<string> Key = new List<string>(0);
            string temp;

            using (StreamReader file = new StreamReader(fileName))
            {
                string[] text = file.ReadToEnd().Split(new char[] { ' ', '\n', '\r' });
                if (text.Length == 0)
                {
                    possible = false;
                    return;
                }

                int indText = 0;
                for (int i = 0; i < K && indText < text.Length; i++)
                {
                    temp = ClearWord(text[indText].Trim(' '));
                    if (temp.Length > 0)
                    {
                        Key.Add(temp.ToLower());
                    }
                    else
                    {
                        i--;
                    }
                    indText++;
                }

                for (int i = indText; i < text.Length; i++)
                {
                    temp = ClearWord(text[i].Trim(' '));
                    if (temp.Length > 0)
                    {
                        temp = temp.ToLower();

                        if (Freq.ContainsKey(Key))
                        {
                            if (Freq[Key].ContainsKey(temp))
                            {
                                Freq[Key][temp]++;
                            }
                            else
                            {
                                Freq[Key].Add(temp, 1);
                            }
                            Count[Key]++;
                        }
                        else
                        {
                            Dictionary<string, int> t = new Dictionary<string, int>(0);
                            t.Add(temp, 1);
                            List<string> l = new List<string>(Key);
                            Freq.Add(l, t);
                            Count.Add(l, 1);
                        }

                        Key.Add(temp);
                        Key.RemoveAt(0);
                    }
                }

                foreach (List<string> i in Freq.Keys)
                {
                    foreach (string j in Freq[i].Keys)
                    {
                        if (Prob.ContainsKey(i))
                        {
                            if (Prob[i].ContainsKey(j))
                            {
                                Prob[i][j] = Freq[i][j] / ((double)Count[i]);
                            }
                            else
                            {
                                Prob[i].Add(j, Freq[i][j] / ((double)Count[i]));
                            }
                        }
                        else
                        {
                            Dictionary<string, double> t = new Dictionary<string, double>();
                            t.Add(j, Freq[i][j] / ((double)Count[i]));
                            Prob.Add(i, t);
                        }
                    }
                }
            }
        }

        private string GetRandomWord(Dictionary<string, double> wordtable)
        {
            List<string> words = new List<string>(0);

            foreach (string i in wordtable.Keys)
            {
                for (int j = 0; j < PrecCoeff * wordtable[i]; j++)
                {
                    words.Add(i);
                }
            }
            if (words.Capacity == 0)
            {
                possible = false;
                return null;
            }
            return words[genNum.Next(words.Count)];
        }
    }
}