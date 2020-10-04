using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopWatch;
        public Chronometer()
        {
            this.stopWatch = new Stopwatch();
        }
        public string GetTime => string.Format("{0:D2}:{0:D2}:{0:D4}", stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);

        public List<string> Laps => throw new NotImplementedException();

        public string Lap()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            stopWatch.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
        }
    }
}
