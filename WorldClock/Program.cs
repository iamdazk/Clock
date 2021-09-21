using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Threading;

namespace WorldClock
{
    
    public class Clock
    {
        private int _hour;
        private int _minute;
        private int _second;
       
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);
        
        public event SecondChangeHandler SecondChange;
        
        protected void OnSecondChange(object clock, TimeInfoEventArgs timeInformation)
        {           
            if (SecondChange != null)
            {         
                SecondChange(clock, timeInformation);
            }
        }
        public void Run()
        {
            for (; ; )
            {
                Thread.Sleep(1000);

                System.DateTime dt = System.DateTime.Now;

                if (dt.Second != _second)
                {
                    TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

                    OnSecondChange(this, timeInformation);

                }
                _second = dt.Second;
                _minute = dt.Minute;
                _hour = dt.Hour;
            }
        }
    }

    public class TimeInfoEventArgs : EventArgs
    {
        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public readonly int hour;
        public readonly int minute;
        public readonly int second;
    }
    public class DisplayClock
    {
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }
        public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Viet nam: {0}:{1}:{2}",ti.hour.ToString(),ti.minute.ToString(), ti.second.ToString());
        }
    }
    public class LogClock
    {
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChange += new Clock.SecondChangeHandler(WriteLogEntry);
        }
        public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Time: {0}:{1}:{2} ",ti.hour.ToString(),ti.minute.ToString(),ti.second.ToString());
        }
    }
    public class Test
    {
        public static void Main()
        {

            Clock theClock = new Clock();

            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theClock);

            LogClock lc = new LogClock();
            lc.Subscribe(theClock);
            theClock.Run();
        }
    }
}  

