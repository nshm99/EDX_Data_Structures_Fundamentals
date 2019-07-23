using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            List<long> output = new List<long>(sourceTables.Length);
            long[] parents = new long[tableSizes.Length];
            for (int i = 0; i < sourceTables.Length; i++)
            {
                long indexSourceParent = sourceTables[i] - 1;
                while (parents[indexSourceParent] != 0)
                    indexSourceParent = parents[indexSourceParent];

                long indexTargetParent = targetTables[i] - 1;
                while (parents[indexTargetParent] != 0)
                    indexTargetParent = parents[indexTargetParent];

                if(indexSourceParent != indexTargetParent)
                {
                    parents[indexSourceParent] = indexTargetParent;
                    tableSizes[indexTargetParent] += tableSizes[indexSourceParent];
                }

                output.Add(tableSizes.Max());
            }
            return output.ToArray();
        }
    }
}