using TestCommon;
using System;
using System.Collections.Generic;

namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);


        public Tuple<long, long>[] Solve(
            long[] array)
        {
            List<Tuple<long, long>> outPut = new List<Tuple<long, long>>();
            int n = (array.Length-1) / 2;
            for(int i = n;i>=0;i--)
            {   
                SiftDown(i,array,outPut);
            }
            return outPut.ToArray();
 
        }

        private void SiftDown(int i, long[] array, List<Tuple<long, long>> outPut)
        {
            int index = i;
            int l = (2 * i) + 1;
            if (l < array.Length && array[l] < array[index])
                index = l;
            int r = (2 * i) + 2;
            if (r < array.Length && array[r] < array[index])
                index = r;
            if (i != index)
            {
                outPut.Add(new Tuple<long, long>(i, index));
                swap(i, index, array);
                SiftDown(index, array,outPut);
            }
        }

        
        private void swap(int i, int index, long[] array)
        {
            long a = array[i];
            array[i] = array[index];
            array[index] = a;
        }
    }

}