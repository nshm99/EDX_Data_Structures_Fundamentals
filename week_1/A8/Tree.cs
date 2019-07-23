using System.Collections.Generic;

namespace A8
{
    internal class Tree
    {
        public int index;
        public List<Tree> childs;
        public Tree() { }
        public Tree(int i)
        {
            index = i;
            childs = new List<Tree>();
        }
        public  void AddChild(Tree child)
        {
            childs.Add(child);
        }
    }
}