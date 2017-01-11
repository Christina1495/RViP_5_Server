using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIP_lab5_server
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration { BinaryConfiguration = new BinaryConfiguration(typeof(CountFunc)) };

            using (var ignite = Ignition.Start(cfg))
            {
                Console.Read();
            }
        }
    }

    internal class CountFunc : IComputeFunc<int[], int>
    {
        public int Invoke(int[] arg)
        {
            int res = 1;
         //   Console.WriteLine("Apply for array:");
            for(int i=0;i<arg.Length;i++)
            {
                res *= arg[i];
               // Console.Write("[" + arg[i].ToString() + "]");
            }
            //Console.WriteLine();
           // Console.WriteLine("Multiply = " + res);
            return res;
        }
    }
}
