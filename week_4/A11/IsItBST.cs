using System;
using System.Collections.Generic;
using TestCommon;

namespace A11
{
    public class IsItBST : Processor
    {
        public IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            //in-Ordre.....................................................................
            node curent = new node(nodes[0][0], 0);
            Stack<node> inStack = new Stack<node>();
            List<long> inOrder = new List<long>();
            while (inStack.Count != 0 || curent.index != -1)
            {
                while (curent.index != -1)
                {
                    inStack.Push(new node(curent.key, curent.index));
                    int leftChildIndex = (int)nodes[curent.index][1];
                    curent.index = leftChildIndex;
                    if (curent.index != -1)
                        curent.key = nodes[curent.index][0];
                }
                curent = inStack.Pop();
                inOrder.Add(curent.key);
                int rightChildIndex = -1;
                rightChildIndex = (int)nodes[curent.index][2];
                curent.index = rightChildIndex;
                if (curent.index != -1)
                    curent.key = nodes[rightChildIndex][0];

            }
            /*long[] unSorted = new long[inOrder.Count];
            for (int i = 0; i < inOrder.Count; i++)
                unSorted[i] = inOrder[i];
            inOrder.Sort();*/
            for (int i = 1; i < inOrder.Count; i++)
            {
                if (inOrder[i - 1] >= inOrder[i])
                    return false;
                
            }
            return true;


        }
    }    
}
