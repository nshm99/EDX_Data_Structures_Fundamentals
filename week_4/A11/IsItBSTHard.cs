using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBSTHard : Processor
    {
        public IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            //in-Ordre.....................................................................
            if (nodes.Length == 0)
                return true;
            Stack<node> inStack = new Stack<node>();
            Stack<long> inStackMin = new Stack<long>();
            List<node> inOrder = new List<node>();
            long min= -1;
            
            node curent = new node(nodes[0][0], 0);
            while (inStack.Count != 0 || curent.index != -1)
            {
                while (curent.index != -1)
                {
                    inStack.Push(new node(curent.key, curent.index));
                    inStackMin.Push(min);
                    int leftChildIndex = (int)nodes[curent.index][1];
                    curent.index = leftChildIndex;
                    if (leftChildIndex != -1)
                    {
                        if (nodes[leftChildIndex][0] == curent.key)
                            return false;
                        curent.key = nodes[leftChildIndex][0];
                        
                    }
                }
                curent = inStack.Pop();
                inOrder.Add(new node(curent.key,(int) inStackMin.Pop()));
                min = curent.key;
                int rightChildIndex = -1;
                rightChildIndex = (int)nodes[curent.index][2];
                curent.index = rightChildIndex;
                if (curent.index != -1)
                {
                    curent.key = nodes[rightChildIndex][0];
                }

            }
            /* long[] unSorted = new long[inOrder.Count];
             for (int i = 0; i < inOrder.Count; i++)
                 unSorted[i] = inOrder[i];
             inOrder.Sort();*/
            for (int i = 1; i < inOrder.Count; i++)
            {
                if (inOrder[i - 1].key > inOrder[i].key)
                    return false;
                if (inOrder[i - 1].key == inOrder[i].key)
                    if (inOrder[i].index != inOrder[i-1].key)
                        return false;
                /*if (i > 1)
                    if (inOrder[i - 2] == inOrder[i - 1])
                        if (inOrder[i - 1] == inOrder[i])
                        {
                            return false;
                        }*/
                            
            }

            return true;
        }
    }
}
