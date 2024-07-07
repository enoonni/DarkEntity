using UnityEngine;

public class SkeletonHealth : MonoBehaviour, IDamageable
{       
    public event IDamageable.DamageIsTakenHandler OnDamageTaken;

    public delegate void OnDeathHandler();
    public event OnDeathHandler OnDeath;

    private DataEnemy _dataSkeleton;    
    private int _currentHealth;    

    public void Initialize(DataEnemy dataSkeleton)
    {
        _dataSkeleton = dataSkeleton;
        _currentHealth = _dataSkeleton.MaxHealth;
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
