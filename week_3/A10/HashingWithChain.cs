using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        public LinkedList<string>[] chains;
        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            chains = new LinkedList<string>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                chains[i] = new LinkedList<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg,bucketCount);
                        break;
                    case "del":
                        Delete(arg,bucketCount);
                        break;
                    case "find":
                        result.Add(Find(arg,bucketCount));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(long bucketCount,
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
                hash = (((hash * x + str[i]) % p) + p) % p;

            return hash % bucketCount;
            

        }

        public void Add(string str,long bucketCount)
        {
            long hash = PolyHash(bucketCount, str, 0, str.Length);
            foreach (var i in chains[hash])
            {
                if (i == str)
                    return;
            }
            chains[hash].AddFirst(str);
        }

        public string Find(string str, long bucketCount)
        {
            long hash = PolyHash(bucketCount, str, 0, str.Length);
            foreach(var i in chains[hash])
            {
                if (i == str)
                    return "yes";
            }
            return "no";
        }

        public void Delete(string str, long bucketCount)
        {
            long hash = PolyHash(bucketCount, str, 0, str.Length);
            chains[hash].Remove(str);
        }

        public string Check(int i)
        {
            if(chains[i].Count == 0)
            { return "-"; }
            List<string> list = new List<string>();
            string result=null;
            foreach(var s in chains[i])
            {
                list.Add(s);
            }
            result = list[0];
            for(int p =1;p<list.Count;p++)
            {
                result += " ";
                result += list[p];
            }

            return result;
        }

    }
}
