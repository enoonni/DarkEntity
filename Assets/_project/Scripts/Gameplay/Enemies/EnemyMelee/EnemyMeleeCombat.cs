using System;
using UnityEngine;
using GameData.Enemy;

namespace Gameplay.Enemys.EnemyMelee
{
    public class EnemyMeleeCombat
    {      
        private DataEnemy _dataEnemy;
        private Transform _skeletonTransform;

        public EnemyMeleeCombat(DataEnemy dataEnemy, Transform skeletonTransform)
        {
            _dataEnemy = dataEnemy;
            _skeletonTransform = skeletonTransform;
        }

        public void Attack()
        {        
            Collider[] collidersInRange = Physics.OverlapSphere(_skeletonTransform.position, _dataEnemy.AttackRange);
            foreach(Collider collider in collidersInRange)
            {
                if(collider != null)
                {
                    if(collider.tag == "Player")
                    {
                        collider.GetComponent<IDamageable>()?.TakeDamage(_dataEnemy.AttackDamage);
                        break;
                    }
                }
            }           
        }
    }
}