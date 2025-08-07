using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Counter
    {
        private int _count;
        private string _name;
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Counter(string name)
        {
            _count = 0;
            _name = name;
        }
        public void Increment()
        {
            _count++;
        }
        
        public void Reset()
        {
            _count = 0;
        }
        public int Ticks
        {
            get
            {
                return _count;
            }
        }
    }
}
