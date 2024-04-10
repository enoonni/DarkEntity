using UnityEngine;

public abstract class HeandlerHealth : MonoBehaviour
{
    public int Health;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
            Death();
    }

    protected abstract void Death();
}
