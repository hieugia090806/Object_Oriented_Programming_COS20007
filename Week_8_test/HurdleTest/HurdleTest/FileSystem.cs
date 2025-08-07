using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurdleTest;

namespace HurdleTest
{
    public class FileSystem //Change internal to public
    {
        private readonly List<Thing> _contents;
        public FileSystem()
        {
            _contents = new List<Thing>();
        }
        public void Add(Thing toAdd) 
        {
            _contents.Add(toAdd);
        }
        public void PrintCounters()
        {
            Console.WriteLine("This File System contains:");
            foreach (var content in _contents)
            {
                content.Print();
            }
        }
    }
}