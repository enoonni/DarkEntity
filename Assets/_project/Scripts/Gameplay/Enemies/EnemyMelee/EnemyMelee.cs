using System;
using System.Collections;
using UnityEngine;
using GameData.Enemy;

namespace Gameplay.Enemys.EnemyMelee
{
    public class EnemyMelee : MonoBehaviour
    {
        public static readonly string Name = "EnemyMelee";

        [SerializeField] private EnemyHitBoxHandler _hitBoxHandler;
        private EnemyMeleeMovement _movement;
        private EnemyMeleeCombat _combat;
        private DataEnemy _dataEnemy;
        private Transform _transform;
        private CharacterController _controller;
        private EnemyHealth _health;


        private void Awake()
        {
            if(_hitBoxHandler != null)
            {
                _hitBoxHandler.OnDamageTaken += GetDamage;
            }

            _dataEnemy = DataEnemy.GetEnemy(Name);
            _transform = GetComponent<Transform>();
            _controller = GetComponent<CharacterController>();

            _movement = new EnemyMeleeMovement(_transform, _dataEnemy, _controller);
            _combat = new EnemyMeleeCombat(_dataEnemy, _transform);

            _movement.OnHasReached += AttackAfterCD;

            _health = new EnemyHealth(_dataEnemy.MaxHealth, 0);
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {
            _movement.Move();
        }

        private void GetDamage(object damage, EventArgs e)
        {
            if(damage != null)
            {
                _health.GetDamage((int)damage);
            }
        }

        private void AttackAfterCD(object sender, EventArgs e)
        {
            _movement.OnHasReached -= AttackAfterCD;
            StartCoroutine(EndAttack());
        }

        private IEnumerator EndAttack()
        {
            yield return new WaitForSeconds(_dataEnemy.AttackSpeed);

            _combat.Attack();

            _movement.OnHasReached += AttackAfterCD;
        }

        private void Death(object sender, EventArgs e)
        {
            Destroy(this.gameObject);
        }
    }
}
