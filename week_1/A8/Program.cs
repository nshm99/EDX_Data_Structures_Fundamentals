using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            PacketProcessing a = new PacketProcessing("TD3");
            a.Solve(1, new long[] { 0, 1 }, new long[] { 1, 1 });
        }
    }
}
