using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class PacketProcessing : Processor
    {
        public PacketProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize,
            long[] arrivalTimes,
            long[] processingTimes)
        {
            List<Packet> packets = new List<Packet>();
            for (int i = 0; i < arrivalTimes.Length; i++)
                packets.Add(new Packet(i, arrivalTimes[i], processingTimes[i]));
            List<long> finish_time = new List<long>();
            long[] result = new long[arrivalTimes.Length];
            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                result[i] = Process(packets[i], ref finish_time, bufferSize);
            }
            return result;
        }

        private long Process(Packet packet, ref List<long> finish_time, long bufferSize)
        {
            while (finish_time.Count > 0 && finish_time.First() <= packet.arrivalTime)
                finish_time.Remove(finish_time.First());
            if (finish_time.Count < bufferSize)
            {
                if (finish_time.Count == 0)
                {
                    finish_time.Add(packet.arrivalTime + packet.processTime);
                    return packet.arrivalTime;
                }
                else
                {
                    if (finish_time.Last() == packet.arrivalTime)
                    {
                        long s = finish_time.Last() + 1;
                        finish_time.Add(s + packet.processTime);
                        return s;

                    }
                    else
                    {
                        if (finish_time.Last() > packet.arrivalTime)
                        {
                            long s = finish_time.Last();
                            finish_time.Add(s + packet.processTime);
                            return s;
                            
                        }
                    }
                }

            }
            return -1;
        }
    }
}
