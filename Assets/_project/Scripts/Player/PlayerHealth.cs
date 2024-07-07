using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{       
    public event IDamageable.DamageIsTakenHandler OnDamageTaken;

    [SerializeField] private int _currentHealth;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
            Death();
        else        
            OnDamageTaken?.Invoke();
        
    }

    public void Death()
    {
       SceneManager.LoadScene("SampleScene");
    }
}
