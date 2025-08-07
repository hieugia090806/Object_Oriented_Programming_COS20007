using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
        //Set the variable
        Counter _Hour = new Counter("Hour"); //Set the _Hour variable
        Counter _Minute = new Counter("Minute"); //Set the _Minute variable
        Counter _Second = new Counter("Second"); //Set the _Second variable
        //Tick() method
        public void Tick()
        {
            _Second.Increment(); //Increase the _second variable by 1
            if (_Second.Ticks > 59) //Checks if the _Sccond variable greater 59
            {
                _Minute.Increment(); //Increase _Minute by 1
                _Second.Reset(); //Reset the _Second variable to 0
                if (_Minute.Ticks > 60) //Checks if _Minute is greater 60
                {
                    _Hour.Increment(); //Increase _Hour by 1
                    _Minute.Reset(); //Reset the _Minute variable to 0
                    if (_Hour.Ticks > 23) //Checks if _Hour is greater 23
                    {
                        Reset(); //Reset the _Hour variable to 0
                    }
                }
            }

        }
        //Reset() method
        public void Reset()
        {
            _Hour.Reset();
            _Minute.Reset();
            _Hour.Reset();
        }
        public string Time()
        {
            return _Hour.Ticks.ToString("D2") + ":" + _Minute.Ticks.ToString("D2") + ":" + _Second.Ticks.ToString("D2");
        }
    }
}
