using UnityEngine;
using System;

namespace Gameplay.Enemys
{
    public class EnemyHitBoxHandler : MonoBehaviour, IDamageable
    {
        public event EventHandler OnDamageTaken;
        public void TakeDamage(int damage)
        {
            OnDamageTaken?.Invoke(damage, null);
        }
    }
}
