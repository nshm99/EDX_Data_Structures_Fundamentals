using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class ParallelProcessing : Processor
    {
        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<long> startTimes = new List<long>((int)threadCount);
            List<Tuple<long, long>> output = new List<Tuple<long, long>>();
            for(int i=0;i<threadCount;i++)
            {
                startTimes.Add(0);
                output.Add(FindThread(startTimes, jobDuration, i));
            }
            for(int i = (int)threadCount;i<jobDuration.Length;i++)
            {
                output.Add(FindThread(startTimes, jobDuration, i));
            }
            return output.ToArray();
        }

        private Tuple<long, long> FindThread(List<long> startTimes, long[] jobDuration, int i)
        {
            int index = MinTime(startTimes);
            long time = startTimes[index];
            startTimes[index] += jobDuration[i];
            return new Tuple<long, long>(index, time);
        }

        private int MinTime(List<long> startTimes)
        {
            long min = long.MaxValue;
            int index=0;
            for (int i = 0; i < startTimes.Count; i++)
                if (startTimes[i] < min)
                {
                    index = i;
                    min = startTimes[i];
                }
            return index;    
        }
    }
}
