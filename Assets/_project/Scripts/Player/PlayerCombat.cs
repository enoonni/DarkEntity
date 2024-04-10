using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private int damage = 30;
    public LayerMask enemyLayers;
    
    public void Attack()
    {
        
        Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            // Debug.Log("We hit " + enemy.name);
            
            EnemyHealth enemyH = enemy.GetComponent<EnemyHealth>();
            
            enemyH.TakeDamage(damage);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null)
            return;

        Gizmos.DrawSphere(_attackPoint.position, _attackRange);
    }

}
