using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Threading;

namespace WorldClock
{

    public class Program
    {
        public static void Main()
        {
            Clock clock = new Clock();
            VietNamClock vietnamclock = new VietNamClock();
            vietnamclock.Subcribe(clock);

            EngLandClock engLandClock = new EngLandClock();
            engLandClock.DangKy(clock);


            clock.Run();
        }
    }
}

