using System;

namespace GameData.Player.PlayerHealth
{
    public class Health
    {
        public static event EventHandler PlayerHealthChanged;
        
        private int _health;

        public Health(int health)
        {
            _health = health;
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            
            if(_health <= 0)
                PlayerHealthChanged?.Invoke(null, null);
        }

    }
}