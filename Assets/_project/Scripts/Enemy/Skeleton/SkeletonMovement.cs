using System.Collections;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{  
    private DataEnemy _dataSkeleton;

    private float _distants;
    public float Distance{ get{ return _distants; } }
    
    private float _waitingTimeAfterReached = 0.75f;

    private bool _hasReached = false;
    public delegate void OnHasReachedHandler();
    public event OnHasReachedHandler OnHasReached;


    private GameObject _player;
    private CharacterController _controller;      

    public void Initialize(DataEnemy dataSkeleton)
    {    
        _dataSkeleton = dataSkeleton;   
        _controller = GetComponent<CharacterController>();

        FindPlayer();
    }

    private void Update()
    {
        RotateEnemy();
    }

    private void FixedUpdate()
    {
        CheckDistants();
        PursuitPlayer();
    }

    private void FindPlayer()
    {
         _player = GameObject.Find("Player");

        if (_player == null)
        {
            Debug.LogError("Не удалось найти игрока с именем: " + "Player");
        }
    }

    private void RotateEnemy()
    {
        var dist = _player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dist, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
    } 

    private void CheckDistants()
    {
        _distants = Vector3.Distance(_player.transform.position, transform.position);
    }

    private void PursuitPlayer()
    {        
        if(_distants > _dataSkeleton.AttackRange && _hasReached == false)
        {
            Vector3 direction = (_player.transform.position - transform.position).normalized;
            _controller.Move(direction * _dataSkeleton.MoveSpeed * Time.deltaTime);
        }
        else if(_hasReached == false)
        {
            _hasReached = true;
            OnHasReached?.Invoke();
            StartCoroutine(WaitAfterReached());
        }
    }

    private IEnumerator WaitAfterReached()
    {        
        yield return new WaitForSeconds(_waitingTimeAfterReached);
        _hasReached = false;
    } 
}
