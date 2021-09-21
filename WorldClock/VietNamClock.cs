using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldClock
{
    public class VietNamClock
    {
        public void Subcribe(Clock clock)
        {
            clock.SecondChange += new Clock.SecondChangeHandler(handler);

        }

        private void handler(object obj, TimeInfoEventArgs eventArgs)
        {
            DateTime dateTime = new DateTime(2000, 1, 1, eventArgs.Hour, eventArgs.Minute, eventArgs.Second);
            Console.WriteLine("VietNamClock: {0}", dateTime.ToLongTimeString());
        }
    }
}
