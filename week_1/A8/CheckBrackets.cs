using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            
            Stack<char> brackets = new Stack<char>();
            Stack<int> index = new Stack<int>();

            for (int i = 0;i < str.Length;i++)
            {
                if (str[i] == '['
                    || str[i] == '{'
                    || str[i] == '(')
                {
                    brackets.Push(str[i]);
                    index.Push(i);
                }

                if (str[i] == ']')
                {
                    if (brackets.Count != 0 && brackets.First() == '[')
                    {
                        brackets.Pop();
                        index.Pop();
                    }
                    else
                    {
                        return i + 1;
                    }

                }

                if (str[i] == '}')
                {
                    if (brackets.Count != 0 && brackets.First() == '{')
                    {
                        brackets.Pop();
                        index.Pop();
                    }
                    else
                    {
                        return i+1;
                    }

                }

                if (str[i] == ')')
                {
                    if (brackets.Count != 0 && brackets.First() == '(')
                    {
                        brackets.Pop();
                        index.Pop();
                    }
                    else
                    {
                        return i+1;
                    }

                }
            }
            if (brackets.Count != 0)
                return index.First()+1;
            return -1;
                
        }
    }
}
