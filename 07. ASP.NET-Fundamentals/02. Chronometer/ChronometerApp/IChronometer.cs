using System.Collections.Generic;

namespace ChronometerApp
{
    public interface IChronometer
    {
        string GetTime { get; }
        List<string> Laps { get; }
        void Start();
        void Stop();
        string Lap();
        void Reset();
    }
}
