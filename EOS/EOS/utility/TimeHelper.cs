using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.utility {
    class TimeHelper {

        public static readonly long MILLISECONDS_PER_FRAME = (int) ((1 / 60f) * 1000);

        public static long Now() {
            return Now(TimeSpan.TicksPerMillisecond);
        }

        public static long Now(long resolution) {
            return DateTime.Now.Ticks / resolution;
        }
    }
}
