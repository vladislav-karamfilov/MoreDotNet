using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDotNet.Runner
{
    using MoreDotNet.Extentions.Common;
    using MoreDotNet.Wrappers;

    class Program
    {
        public static void Main(string[] args)
        {
            var sampleVariable = "Test";
            var test = new Random().OneOf(1, 2, 3, 4);
            Console.WriteLine(test);

            // 1. 
            if (string.IsNullOrWhiteSpace(sampleVariable))
            {
                // Do stuff
            }

            // 2.
            if (sampleVariable.IsNullOrWhiteSpace())
            {
                // Do stuff
            }
        }
    }
}
