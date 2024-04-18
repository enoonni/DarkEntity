using UnityEngine;

public class DarkBallController : MonoBehaviour
{
    private float _ballSpeed = 20f;
    private float _lifetime = 2f;
    private int _damage = 50;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _ballSpeed * Time.deltaTime);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        
        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
            Destroy(gameObject, 0.1f);
        }
    }
}
