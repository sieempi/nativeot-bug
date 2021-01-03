using System;
using System.IO;

using System.Threading.Tasks;
using System.Threading;
//using Newtonsoft.Json;
using System.Text;
using System.Globalization;
using lib1;
using lib2;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datetime = new DateTime(1952, 6, 3); //	leap year to enter lock

            int year, month, day;

            Console.Write("lib1:");
            lib1.DateTimeUtils.GetDateValues(datetime, out year, out month, out day);
            Console.WriteLine($"\t{year}\t{month}\t{day}");

            Console.Write("lib2:");
            lib2.DateTimeUtils.GetDateValues(datetime, out year, out month, out day);
            Console.WriteLine($"\t{year}\t{month}\t{day}");

            Console.WriteLine("bye");


        }


    }
}
