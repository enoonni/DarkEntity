using UnityEngine;

public class SkeletonHealth : MonoBehaviour, IDamageable
{   
    private int _currentHealth;

    private DataEnemy _dataSkeleton;

    private void Start()
    {
        _dataSkeleton = DataEnemy.GetEnemy("Skeleton");

        _currentHealth = _dataSkeleton.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
            Death();
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
