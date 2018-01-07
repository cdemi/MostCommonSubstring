using System;
using System.Collections.Generic;
using System.Linq;

namespace MostCommonSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test Data
            Console.WriteLine(MostCommonSubstring(5, 2, 4, 26, "abcde"));
        }

        private static int MostCommonSubstring(int n, int k, int l, int m, string str)
        {
            Dictionary<string, int> substrings = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < n; i++)
            {
                int maxBounds;
                if (k < n - i)
                    maxBounds = k;
                else
                    maxBounds = n - 1;

                for (int j = k; j <= maxBounds; j++)
                {
                    string substring = str.Substring(i, j);
                    int distinctCharacters = substring.Distinct().Count();

                    if (substring.Length >= k && substring.Length <= l && distinctCharacters <= m)
                    {
                        if (substrings.ContainsKey(substring))
                            substrings[substring]++;
                        else
                            substrings.Add(substring, 1);
                    }
                }
            }

            return substrings.Max(s => s.Value);
        }
    }
}
