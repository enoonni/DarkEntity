using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    private GameObject _player;
    private CharacterController _controller;
    private float _distants;
    public bool IsMoving{get; private set;} = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>(); 
    }

    private void FindPlayer()
    {
         _player = GameObject.Find("Player");

        if (_player == null)
        {
            Debug.LogError("Не удалось найти игрока с именем: " + "Player");
        }
    }

    private void CheckDistants()
    {
        _distants = Vector3.Distance(_player.transform.position, transform.position);
    }

    private void PursuitPlayer()
    {
        if(_distants > 5)
        {
            if(IsMoving == false)
                IsMoving = true;
            Vector3 direction = (_player.transform.position - transform.position).normalized;

            _controller.Move(direction * _moveSpeed * Time.deltaTime);
        }
        else   
            if(IsMoving == true)
                IsMoving = false;
    }

    private void Start()
    {
        FindPlayer();
    }

    private void Update()
    {
        CheckDistants();
    }

    private void FixedUpdate()
    {
        PursuitPlayer();
        RotateEnemy();
    }

    private void RotateEnemy()
    {
        var dist = _player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dist, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
    }  
}
