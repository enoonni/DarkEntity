using UnityEngine;

public class SkeletonRange : MonoBehaviour
{
   [SerializeField] private DataEnemy _skeletonRangeData;
    
    private SkeletonRangeHealth _skeletonRangeHealth;
    private SkeletonRangeMovement _skeletonRangeMovement;
    private SkeletonRangeCombat _skeletonRangeCombat;

    private void Start()
    {
        _skeletonRangeHealth = GetComponent<SkeletonRangeHealth>();
        _skeletonRangeHealth.Initialize(_skeletonRangeData);
        _skeletonRangeHealth.OnDeath += Death;

        _skeletonRangeMovement = GetComponent<SkeletonRangeMovement>();
        _skeletonRangeMovement.Initialize(_skeletonRangeData);

        _skeletonRangeCombat = GetComponent<SkeletonRangeCombat>();
        //_skeletonRangeCombat.Initialize(_skeletonRangeMovement, _skeletonRangeData.AttackDamage, _skeletonRangeData.AttackRange, _skeletonRangeData.AttackSpeed);
    }

    private void Death()
    {
        _skeletonRangeHealth.OnDeath -= Death;
        Destroy(this.gameObject);
    }
    
}
