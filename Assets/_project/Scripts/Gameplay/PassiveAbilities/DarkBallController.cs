using UnityEngine;

namespace Gameplay.PassiveAbillites.DarkBall
{
    public class DarkBallController : MonoBehaviour
    {
        private float _ballSpeed = 20f;
        private float _lifetime = 2f;
        private int _damage = 50;    

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * _ballSpeed * Time.deltaTime);
            _lifetime -= Time.deltaTime;
            if(_lifetime <= 0)
                Destroy(this.gameObject);
        }

        
        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();
            
            if(damageable != null)
            {
                damageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
