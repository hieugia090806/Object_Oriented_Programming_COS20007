using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurdleTest;

namespace HurdleTest
{
    public class Folder : Thing //Change internal to public
    {
        private List<Thing> _contents; //Delete the "readonly"
        public Folder(string name) : base(name)
        {
            _contents = new List<Thing>();
        }
        public void Add(Thing toAdd) // Modified from Add(File toAdd)
        {
            _contents.Add(toAdd);
        }
        public override int Size()
        {
            int totalSize = 0;
            foreach (Thing file in _contents)
            {
                totalSize += file.Size();
            }
            return totalSize;
        }
        public override void Print()
        {
            if (_contents.Count == 0)
            {
                Console.WriteLine($"The Folder: '{Name}' is empty!");
            }
            else
            {
                Console.WriteLine($"The Folder: '{Name}' contains {_contents.Count} things totalling {Size()} bytes:");
                foreach (var content in _contents)
                {
                    content.Print();
                }
            }
        }
    }
}