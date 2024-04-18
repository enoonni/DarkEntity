using UnityEngine;

public class SkeletonHealth : MonoBehaviour, IDamageable
{   
    private int _currentHealth;
    
    private DataEnemy _dataSkeleton;

    public delegate void OnDeathHandler();
    public event OnDeathHandler OnDeath;

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
    }
}
