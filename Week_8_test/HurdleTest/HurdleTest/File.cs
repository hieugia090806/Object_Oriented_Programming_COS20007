using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurdleTest;

namespace HurdleTest
{
    public class File : Thing //Change internal to public
    {
        private readonly string _name;
        private readonly string _extension;
        private readonly int _size;
        public File(string name, string extension, int size) : base(name)
        {
            _extension = extension;
            _size = size;
        }
        public override int Size()
        {
            return _size;
        }
        public override void Print()
        {
            Console.WriteLine($"File: '{Name}.{_extension}' Size: {_size} bytes");
        }
    }
}
