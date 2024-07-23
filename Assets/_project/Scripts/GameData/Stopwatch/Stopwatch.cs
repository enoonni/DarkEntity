using System;

namespace GameData.Stopwatch
{
    public static class Stopwatch
    {
        private static float _currentTimeGame;
        private static bool GameIsRunning = false;

        
        public static event EventHandler TimeIsChanged;
        
        public static void StartStopwatch()
        {
            GameIsRunning = true;
            _currentTimeGame = 0;
        }

        public static void ContinueStopwatch()
        {
            GameIsRunning = true;
        }

        public static void StopStopwatch()
        {
            GameIsRunning = false;
        }

        public static void AddTime(float time)
        {            
            if(GameIsRunning == true)
            {
                var lastTime = _currentTimeGame;
                _currentTimeGame += time;

                if((int)lastTime != (int)_currentTimeGame)
                {
                    TimeIsChanged?.Invoke(_currentTimeGame, null);
                }
            }
        }
    }
}