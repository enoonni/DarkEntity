using System;

namespace GameData.Enemy
{
    public class EnemyHealth
    {
        public int Health{get; private set;}
        public int Armor{get; private set;}

        public event EventHandler HealthIsChanged;
        public event EventHandler Death;

        public EnemyHealth(int health, int armor)
        {
            Health = health;
            Armor = armor;
        }

        public void GetDamage(int damage)
        {
            var healthBeforeDamage = Health;
            damage -= Armor;
            if(damage > 0)
            {
                Health -= damage;
                if(Health <= 0)
                {
                    Health = 0;
                    HealthIsChanged?.Invoke(Health, null);
                    Death?.Invoke(null, null);
                }
                else
                {
                    HealthIsChanged?.Invoke(Health, null);
                }
            }
        }

    }
}
