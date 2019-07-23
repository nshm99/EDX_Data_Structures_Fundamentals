using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class Program
    {
        static void Main(string[] args)
        {
            HashingWithChain a = new HashingWithChain("TD2");
            a.Solve(5, new string[] {"add test","add test","find test","check 0",
                "check 1","check 2","check 3","check 4",
                "del test","del test","find test","find Test","add Test","find Test" });
            

        }
    }
}
