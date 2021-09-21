using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldClock
{
    class EngLandClock
    {
        public void DangKy(Clock clock)
        {
            clock.SecondChange += new Clock.SecondChangeHandler(xuly);

        }

        private void xuly(object obj, TimeInfoEventArgs eventArgs)
        {
            DateTime dateTime = new DateTime(2000,1,1, eventArgs.Hour, eventArgs.Minute, eventArgs.Second);
            DateTime newDateTime = dateTime.AddHours(-6); 

            Console.WriteLine("EngLandClock: {0}", newDateTime.ToLongTimeString());
        }
    }
}
