using System;

namespace GameData.Player.PlayerData
{
    public class Health
    {
        public static event EventHandler PlayerHealthChanged;
        public static event EventHandler Death;
        public static int _health{get; private set;}        

        public Health(int health)
        {
            _health = health;
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            
            if(_health <= 0)
            {
                _health = 0;
                PlayerHealthChanged?.Invoke(null, null);
                Death?.Invoke(null, null);
            }
            else
            {
                PlayerHealthChanged?.Invoke(null, null);
            }                
        }

    }
}