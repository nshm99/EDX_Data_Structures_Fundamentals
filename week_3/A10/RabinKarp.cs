using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class RabinKarp : Processor
    {
        public RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            long prime = 1000000007;
            long x = 236;
            List<long> positionList = new List<long>();
            long[] hashText = PreComputeHashes(text, pattern.Length, prime, x);
            long hashPatern = PolyHash(pattern, 0, pattern.Length, prime, x);
            

            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if (hashText[i] == hashPatern)
                {
                    if (AreEqual(pattern, text, i, i + pattern.Length))
                        positionList.Add(i);
                }

            }
            return positionList.ToArray();
        }

        private bool AreEqual(string pattern, string text, int first, int end)
        {
            for (int i = first; i < end; i++)
                if (pattern[i - first] != text[i])
                    return false;

            return true;
        }
        
        public static long[] PreComputeHashes(
            string text,
            int paterbLen,
            long prime,
            long x)
        {
            long[] hash = new long[text.Length - paterbLen + 1];

            hash[text.Length - paterbLen] = PolyHash(text, text.Length - paterbLen, paterbLen, prime, x);

            long y = 1;
            for (int i = 1; i <= paterbLen; i++)
                y = (((y * x) % prime) + prime) % prime;

            for (int i = text.Length - paterbLen - 1; i >= 0; i--)
                hash[i] = (((x * hash[i + 1] + text[i] - y * text[i + paterbLen]) % prime + prime) % prime);

            return hash;
        }
        
        private static long PolyHash(string str, int start, int paterbLen, long p,
            long x)
        {
            long hash = 0;

            for (int i = start + paterbLen - 1; i >= start; i--)
                hash = (((hash * x + str[i]) % p) + p) % p;

            return hash;
        }
    }
}
