using UnityEngine;
using GameData.Enemy;
using GameData.Player.Experience;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private DataEnemy _skeletonData;
    
    private SkeletonHealth _skeletonHealth;
    private SkeletonMovement _skeletonMovement;
    private SkeletonCombat _skeletonCombat;

    private void Start()
    {
        _skeletonHealth = GetComponent<SkeletonHealth>();
        _skeletonHealth.Initialize(_skeletonData);
        _skeletonHealth.OnDeath += Death;

        _skeletonMovement = GetComponent<SkeletonMovement>();
        _skeletonMovement.Initialize(_skeletonData);

        _skeletonCombat = GetComponent<SkeletonCombat>();
        _skeletonCombat.Initialize(_skeletonMovement, _skeletonData.AttackDamage, _skeletonData.AttackRange, _skeletonData.AttackSpeed);
    }

    private void Death()
    {
        Experience.AddExperience((uint)_skeletonData.GetExp);
        _skeletonHealth.OnDeath -= Death;
        Destroy(this.gameObject);
    }
    
}
