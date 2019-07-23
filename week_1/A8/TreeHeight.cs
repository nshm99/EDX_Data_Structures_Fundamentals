using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class TreeHeight : Processor
    {
        public TreeHeight(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            List<Tree> nodes = new List<Tree>();
            Tree root = new Tree();
            for(int i =0;i<nodeCount;i++)
            {
                nodes.Add(new Tree(i));
            }
            for(int i=0;i<nodeCount;i++)
            {
                if (tree[i] == -1)
                    root = nodes[i];
                else
                    nodes[(int)tree[i]].AddChild(nodes[i]);
            }

            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(root);
            int count = 0;
            long height = 0;
            while (queue.Count() > 0)
            {
                count = queue.Count();
                if (count > 0)
                    height++;
                for (int i = 0; i < count; i++)
                {
                    Tree a = queue.Dequeue();
                    foreach (var ch in a.childs)
                    {
                        queue.Enqueue(ch);
                    }
                }
            }
            return height;
        }

        /*private long DeptByBFS(Tree root, List<Tree> nodes)
        {
            

        }

        private int IndexOf(int v, long nodeCount, long[] tree)
        {
            for (int i = 0; i < nodeCount; i++)
                if (tree[i] == v)
                    return i;
            return -1;
        }*/
    }
}
