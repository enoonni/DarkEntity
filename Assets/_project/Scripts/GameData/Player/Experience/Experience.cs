using System;

namespace GameData.Player.Experience
{
    public class Experience
    {
        public static uint CurrentExperience{get; private set;} = 0;
        public static uint CurrentLevel{get; private set;} = 1;

        public static event EventHandler LevelIsChaged;
        public static event EventHandler ExperienceIsChaged;

        public static void AddExperience(uint experience)
        {
            CurrentExperience += experience;
            ExperienceIsChaged?.Invoke(CurrentExperience, null);

            if(CurrentExperience >= (CurrentLevel * 1000))
            {
                while(CurrentExperience >= (CurrentLevel * 1000))
                {
                    CurrentExperience -= (CurrentLevel++ * 1000);
                    LevelIsChaged?.Invoke(CurrentLevel, null);
                }
            }
        }
    }
}
