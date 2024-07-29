using System.Collections;
using UnityEngine;
using Gameplay;
using GameData.Enemy;

public class SkeletonCombat : MonoBehaviour
{
    public delegate void OnAttacksHandler();
    public event OnAttacksHandler OnAttacks;

    private SkeletonMovement _skeletonMovment;

    private int _attackDamage;
    private float _attackRange;
    private float _attackSpeed;

    public void Initialize(SkeletonMovement skeletonMovement, int attackDamage, float attackRange, float attackSpeed )
    {
        _attackDamage = attackDamage;
        _attackRange = attackRange;
        _attackSpeed = attackSpeed;

        _skeletonMovment = skeletonMovement;
        _skeletonMovment.OnHasReached += Attack;
    }
    private void Attack()
    {   
        _skeletonMovment.OnHasReached -= Attack;
        OnAttacks?.Invoke();

        StartCoroutine(EndAttack());
    }
    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(_attackSpeed);
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, _attackRange);
        foreach(Collider collider in collidersInRange)
        {
            if(collider != null && collider.tag == "Player")
            {
                collider.GetComponent<IDamageable>()?.TakeDamage(_attackDamage);
                break;
            }
        }

        _skeletonMovment.OnHasReached += Attack;
    }
}
