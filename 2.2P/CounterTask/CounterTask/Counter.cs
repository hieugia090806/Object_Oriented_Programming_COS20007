using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Counter
    {
        private double _count;
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
            _name = name;
            _count = 0;
        }
        public void Increment()
        {
            _count++;
        }
        
        public void Reset()
        {
            _count = 0;
        }
        public double Ticks
        {
            get
            {
                return _count;
            }
        }

        public void ResetByDefault()
        {
            _count = 214783647520;
        }
    }
}
