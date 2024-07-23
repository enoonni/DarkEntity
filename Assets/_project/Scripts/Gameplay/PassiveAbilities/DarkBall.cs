using UnityEngine;

namespace Gameplay.PassiveAbillites.DarkBall
{
    public class DarkBall : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        private float _kdBall = 1f;
        private float _shootTimer = 0f;

        private void FixedUpdate()
        {
            _shootTimer -= Time.deltaTime;
            if (_shootTimer <= 0f)
            {
                Shoot();
                _shootTimer = _kdBall;
            }
        }

        private void Shoot()
        {
            GameObject darkBall = Instantiate(_ballPrefab, transform.position, transform. rotation);
        }
    }
}
