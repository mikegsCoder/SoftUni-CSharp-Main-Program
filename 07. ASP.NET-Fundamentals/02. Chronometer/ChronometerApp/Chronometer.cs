using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronometerApp
{
    internal class Chronometer : IChronometer
    {
        private Stopwatch stopWatch;
        private List<string> laps;

        public Chronometer()
        {
            this.stopWatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => this.stopWatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => this.laps;

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
            this.stopWatch.Start();
        }

        public void Stop()
        {
            this.stopWatch.Stop();
        }
    }
}
