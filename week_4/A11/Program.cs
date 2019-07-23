using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    class Program
    {
        static void Main(string[] args)
        {
            IsItBSTHard a = new IsItBSTHard("a");
            a.Solve(new long[][]
                {new long[]{9,4,1},
                new long[]{11,5,-1},
                new long[]{0,-1,-1},
                new long[]{9,-1,-1},
                new long[]{2,2,3},
                new long[]{9,-1,-1},}
                );

        }
    }
}
