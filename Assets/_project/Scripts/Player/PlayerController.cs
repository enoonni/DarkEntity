using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    public static PlayerController Instance {get; private set;}
    public Transform TransformPlayer {get; private set;}
    private Vector3 _mousePoint;
    private Camera _mainCamera;
    private CharacterController _characterController;
    
    [SerializeField] private float _moveSpeed = 5;

    [SerializeField] private float _fallSpeed = 10;
    
      
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        _mainCamera = Camera.main;
        _characterController = GetComponent<CharacterController>();
        
        TransformPlayer = GetComponent<Transform>();
    }    

    private void FixedUpdate()
    {
        Move(InputSystemHandler.Instance.MoveDirection);
        Fall();
    }

    private void Update()
    {
        UpdateMousePoint();                
        RotatePlayer();
    }    
    
    private void Move(Vector2 MoveDirection)
    {
        Vector3 offset = new Vector3(MoveDirection.x, 0f, MoveDirection.y) * _moveSpeed * Time.deltaTime;
        _characterController.Move(offset);
    }

    private void Fall()
    {
        if(_characterController.isGrounded == false)
            _characterController.Move(new Vector3(0f, -_fallSpeed, 0f)  * Time.deltaTime);
    }


    private void UpdateMousePoint()
    {
        Ray mousePointRay = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(mousePointRay, out RaycastHit mouseRaycastHit);
        _mousePoint = mouseRaycastHit.point;
    }

    private void RotatePlayer()
    {
        var dist = _mousePoint - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dist, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
    }    
}
