using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorldClock
{

    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        public delegate void SecondChangeHandler(object obj, TimeInfoEventArgs eventArgs);

        public event SecondChangeHandler SecondChange;

        private void OnSecondChange(object clock, TimeInfoEventArgs eventArgs)
        {
            if (SecondChange != null)
            {
                SecondChange(clock, eventArgs);
            }
        }
        
        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);

                DateTime nowDateTime = DateTime.Now;

                if (nowDateTime.Second != this.second)
                {
                    TimeInfoEventArgs timeInfoEventArgs = new TimeInfoEventArgs(nowDateTime.Hour,nowDateTime.Minute,nowDateTime.Second);
                    OnSecondChange(this, timeInfoEventArgs);
                }
                this.hour = nowDateTime.Hour;
                this.minute = nowDateTime.Minute;
                this.second = nowDateTime.Second;

            }
        }


    }
}
