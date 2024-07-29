using System;

namespace Gameplay
{
    public interface IDamageable
    {
        public event EventHandler OnDamageTaken;
        public void TakeDamage(int damage);
    }
}