using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData.Enemy;

public class SkeletonRangeHealth : MonoBehaviour
{
    public event IDamageable.DamageIsTakenHandler OnDamageTaken;

    public delegate void OnDeathHandler();
    public event OnDeathHandler OnDeath;

    private DataEnemy _dataSkeletonRange;    
    private int _currentHealth;  

    public void Initialize(DataEnemy dataSkeletonRange)
    {
        _dataSkeletonRange = dataSkeletonRange;
        _currentHealth = _dataSkeletonRange.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
            OnDeath?.Invoke();
        else
            OnDamageTaken?.Invoke();
    }
}
