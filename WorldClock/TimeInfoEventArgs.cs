using System;

namespace WorldClock
{
    public class TimeInfoEventArgs : EventArgs
    {
        private int hour;
        private int minute;
        private int second;

        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public int Hour { get => hour; private set => hour = value; }
        public int Minute { get => minute; private set => minute = value; }
        public int Second { get => second; private set => second = value; }
    }
}