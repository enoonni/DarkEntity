using UnityEngine;
using GameData.Stopwatch;
using Gameplay.Enemys;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        private EnemyGenerator _enemyGenerator;
        private float _stopwatch = 0.2f;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _enemy;
        
        void Start()
        {
            _enemyGenerator = EnemyGenerator.Instance;
            _enemyGenerator.Initialize(10, 6, _player.transform);

            Stopwatch.StartStopwatch();
        }
        
        void Update()
        {
            if(_stopwatch <= 0)
            {
                _stopwatch = 1f;
                _enemyGenerator.SpawnEnemy(_enemy);
            }
            else if(_stopwatch > 0)
                _stopwatch -= Time.deltaTime;
        }

        void FixedUpdate()
        {
            Stopwatch.AddTime(Time.deltaTime);
            
        }
    } 
}
