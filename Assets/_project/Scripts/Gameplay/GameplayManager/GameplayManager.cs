using UnityEngine;
using GameData.Stopwatch;
using Gameplay.Enemys;
using GameData.Player.PlayerData;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {        
        //private float _stopwatch = 0.2f;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _enemy;
        private int i = 0;
        
        private void Awake()
        {

        }

        private void Start()
        { 
            Stopwatch.StartStopwatch();
        }
        
        void Update()
        {
           
        }

        void FixedUpdate()
        {
            Stopwatch.AddTime(Time.deltaTime);
            if(i++ < 10)
            {
                EnemyGenerator.Instance.SpawnEnemy(_enemy);
            }
        }
    } 
}
