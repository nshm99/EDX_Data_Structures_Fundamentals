using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A11
{
    public class BinaryTreeTraversals : Processor
    {
        public BinaryTreeTraversals(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);


        public long[][] Solve(long[][] nodes)
        {
            Stack<node> preStack = new Stack<node>();
            Stack<node> postStack = new Stack<node>();
            Stack<node> inStack = new Stack<node>();
            List<long> preOrder = new List<long>();
            List<long> postOrder = new List<long>();
            List<long> inOrder = new List<long>();
            node root = new node(nodes[0][0], 0);
            //pre-Order....................................................................
            preStack.Push(root);
            while (preStack.Count !=0)
            {
                node a = preStack.Pop();
                preOrder.Add(a.key);
                int leftChildIndex = (int)nodes[a.index][1];
                int rightChildIndex = (int)nodes[a.index][2];
                if(rightChildIndex!=-1)
                    preStack.Push(new node(nodes[rightChildIndex][0], rightChildIndex));
                if (leftChildIndex != -1)
                    preStack.Push(new node(nodes[leftChildIndex][0], leftChildIndex));

            }
            //in-Ordre.....................................................................
            node curent = new node(nodes[0][0], 0);
            
            while(inStack.Count!=0 || curent.index!=-1)
            {
                while (curent.index != -1)
                {
                    inStack.Push(new node(curent.key,curent.index));
                    int leftChildIndex = (int)nodes[curent.index][1];
                    curent.index = leftChildIndex;
                    if(leftChildIndex != -1)
                        curent.key = nodes[leftChildIndex][0];
                }
                curent = inStack.Pop();
                inOrder.Add(curent.key);
                int rightChildIndex = -1;
                rightChildIndex= (int)nodes[curent.index][2];
                curent.index = rightChildIndex;
                if(curent.index != -1)
                curent.key = nodes[rightChildIndex][0];

            }
            //post-Order...................................................................
         
            do
            {
                while (root.index != -1)
                {
                    int rightIndex = (int)nodes[root.index][2];
                    int leftChildIndex = (int)nodes[root.index][1];
                    if (rightIndex != -1)
                        postStack.Push(new node(nodes[rightIndex][0], rightIndex));
                    postStack.Push(new node(root.key, root.index));
                    root.index = leftChildIndex;
                    if (leftChildIndex != -1)
                        root.key = nodes[leftChildIndex][0];
                }
                root = postStack.Pop();
                int rightChildIndex = (int)nodes[root.index][2];
                long rightChild = -1;
                if (rightChildIndex != -1)
                    rightChild = nodes[rightChildIndex][0];
                node second = new node();
                if (postStack.Count != 0)
                {
                    second = postStack.Pop();
                    postStack.Push(new node(second.key, second.index));
                }
                if (rightChildIndex != -1 && rightChild == second.key && rightChildIndex == second.index)
                {
                    postStack.Pop();
                    postStack.Push(new node(root.key, root.index));
                    root = new node(second.key,second.index); 
                }
                else
                {
                    postOrder.Add(root.key);
                    root.index = -1;
                }
            } while (postStack.Count != 0);
            //
            long[][] result = new long[3][] { inOrder.ToArray(), preOrder.ToArray(), postOrder.ToArray() };
            
            return result;
        }
    }
}
