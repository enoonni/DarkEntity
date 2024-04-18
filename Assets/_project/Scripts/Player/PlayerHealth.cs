using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{   
    public delegate void PlayerTakeDamageHandler();
    public event PlayerTakeDamageHandler OnPlayerTakeDamage;

    [SerializeField] private int _currentHealth;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnPlayerTakeDamage?.Invoke();

        if(_currentHealth <= 0)
            Death();
        else
            BodyTakeDamageColor.Instance.SwitchColor();
    }

    public void Death()
    {
       SceneManager.LoadScene("SampleScene");
    }
}
