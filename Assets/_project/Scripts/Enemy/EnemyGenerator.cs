using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemys
{
    public class EnemyGenerator : MonoBehaviour
    {
        public static EnemyGenerator Instance = null;
        private List<GameObject> _listEnemys;
        private List<GameObject> _listSpawnPoints;

        [SerializeField] private float _distanceToPlayer;
        [SerializeField] private int _maxAmountPoints;

        [SerializeField] private GameObject _point;        
        [SerializeField] private GameObject _enemy;        

        [HideInInspector] public Transform PlayerTransform;
        [HideInInspector] public Transform EnemyGeneratorTransform;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            EnemyGeneratorTransform = GetComponent<Transform>();
            _listSpawnPoints = new List<GameObject>();
        }

        private void Start()
        {
            PlayerTransform = PlayerController.Instance.TransformPlayer;  
            SetPoints();   

            StartCoroutine(Spawning());         
        }    

        private void FixedUpdate()
        {
            MoveForPlayer();           
        }

        private void MoveForPlayer()
        {
            EnemyGeneratorTransform.position = PlayerTransform.position;
        }

        private float GetAngle()
        {
            return  (360 / _maxAmountPoints);
        }

        private void SpawnPoint()
        {
            GameObject point = Instantiate(_point, EnemyGeneratorTransform.position, EnemyGeneratorTransform.rotation);      

            point.transform.parent = EnemyGeneratorTransform;

            _listSpawnPoints.Add(point);        
        }

        private void SetPointsPosition()
        {
            int count = 1;

            foreach(GameObject point in _listSpawnPoints)
            {
                point.transform.position = EnemyGeneratorTransform.position;

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

        public void SpawnEnemyRandomPoint(GameObject enemy)
        {
            var point = _listSpawnPoints[Random.Range(0, _listSpawnPoints.Count)].transform;
            Instantiate(enemy, point.transform.position, point.rotation);
        }  
        
        private IEnumerator Spawning()
        {
            int i = 0;
            while (i++ < 50)
            {
                yield return new WaitForSeconds(1.0f);
                SpawnEnemyRandomPoint(_enemy);
            }
        }    
    }
}

