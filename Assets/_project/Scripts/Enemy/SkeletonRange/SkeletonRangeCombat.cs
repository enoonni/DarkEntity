using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRangeCombat : MonoBehaviour
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
        
    }
}
