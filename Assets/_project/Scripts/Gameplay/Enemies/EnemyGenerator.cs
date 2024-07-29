using System.Collections.Generic;
using UnityEngine;
using GameData.Player.PlayerData;

namespace Gameplay.Enemys
{
    public class EnemyGenerator : MonoBehaviour
    {
        public static EnemyGenerator Instance = null;
        private List<GameObject> _listSpawnPoints;

        private float _distanceToPlayer;
        private int _maxAmountPoints;

        [SerializeField] private GameObject _point;    

        private Transform _playerTransform;
        private Transform _enemyGeneratorTransform;

        private void Start()
        {
            Initialize(10f, 6, PlayerInfo.PlayerTransform);
        }

        private void FixedUpdate()
        {
            MoveForPlayer();
        }

        public void Initialize(float distanceToPlayer, int maxAmountPoints, Transform playerTransform)
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
            
            _distanceToPlayer = distanceToPlayer;
            _maxAmountPoints = maxAmountPoints;
            _playerTransform = playerTransform;

            _enemyGeneratorTransform = GetComponent<Transform>();
            _listSpawnPoints = new List<GameObject>();

            SetPoints(); 
        }       

        public void MoveForPlayer()
        {
            if(_playerTransform != null)
                _enemyGeneratorTransform.position = _playerTransform.position;
        }

        private float GetAngle()
        {
            return  (360 / _maxAmountPoints);
        }

        private void SpawnPoint()
        {
            GameObject point = Instantiate(_point, _enemyGeneratorTransform.position, _enemyGeneratorTransform.rotation);      

            point.transform.parent = _enemyGeneratorTransform;

            _listSpawnPoints.Add(point);        
        }

        private void SetPointsPosition()
        {
            int count = 1;

            foreach(GameObject point in _listSpawnPoints)
            {
                point.transform.position = _enemyGeneratorTransform.position;

                point.transform.rotation = Quaternion.Euler(0, point.transform.rotation.y + (GetAngle() * count++) + 180f, 0);
                point.transform.position = point.transform.position + point.transform.forward * _distanceToPlayer;
            }
        }  

        private void SetPoints()
        {
            for(int i = 0; i < _maxAmountPoints; i++)
            {
                SpawnPoint();
            }

            SetPointsPosition();
        }     

        private void SpawnEnemyRandomPoint(GameObject enemy)
        {
            var point = _listSpawnPoints[Random.Range(0, _listSpawnPoints.Count)].transform;
            Instantiate(enemy, point.transform.position, point.rotation);
        }

        public void SpawnEnemy(GameObject enemy)
        {
            SpawnEnemyRandomPoint(enemy);
        } 
    }
}

