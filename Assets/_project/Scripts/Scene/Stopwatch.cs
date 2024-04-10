using System;

namespace Scene
{
    class Stopwatch
    {
        static public uint Seconds {get; private set;}
        static private bool _isWorking = false;

        public Stopwatch()
        {
            Seconds = 0;
        }

        public void UpdateSeconds()
        {
            if(_isWorking)
            {
                Seconds++;
            }
        }

    }
}