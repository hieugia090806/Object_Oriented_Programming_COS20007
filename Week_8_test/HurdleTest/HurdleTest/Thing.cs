﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurdleTest
{
    public abstract class Thing //Chane internal to public abstract
    {
        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }

        public Thing (string name)
        {
            _name = name;
        }
        public abstract int Size();
        public abstract void Print();

    }
}
