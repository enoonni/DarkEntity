public interface IDamageable
{
    public delegate void DamageIsTakenHandler();
    public event DamageIsTakenHandler OnDamageTaken;

    void TakeDamage(int damage);
}
