using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 _move;
    [SerializeField] private Vector3 look;
    [SerializeField] private Vector3 point;
    [SerializeField] private Vector3 obj;
    [SerializeField] private Vector3 intersectionPoint;
    
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private GameObject plane;

   
    

    private PlayerInput _input = null;    
      
    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Move.performed += OnMovePerformed;
        _input.Player.Move.canceled += OnMoveCancelled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Move.performed -= OnMovePerformed;
        _input.Player.Move.canceled -= OnMoveCancelled;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
    }

    private void OnMoveCancelled(InputAction.CallbackContext context)
    {
        _move = Vector2.zero;
    }

    private void Move()
    {
        Vector3 offset = new Vector3(_move.x, 0f, _move.y) * _moveSpeed * Time.deltaTime;
        transform.Translate(offset);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        point = Mouse.current.position.ReadValue();
        obj = Camera.main.ScreenToWorldPoint(new Vector3(point.x, point.y, Camera.main.nearClipPlane));
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(point);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform == plane.transform)
            {
                look = hit.point;
            }
        }
        var lookDir = look - transform.position;
        float angle = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg;        
        
        transform.rotation = Quaternion.Euler(0f, angle * -1 - 270, 0f);

        //Physics.Raycast(ray, out hit);
        //if(hit.collider == plane)
        //{
            //look = hit.transform.position;
        //}

        float maxRaycastDistance = 100f;

        //if(Physics.Raycast(ray, out hit, maxRaycastDistance))
        //{
         //  if(hit.collider == plane)
         //   {
        //        look = hit.transform.position;
         //   }
        //}
        // {
        //     // Получаем позицию точки пересечения луча с поверхностью
        //     Vector3 ggwp = hit.point;
            
        //     // Останавливаем луч, когда ось Y луча равна 0
        //     if (Mathf.Approximately(ggwp.y, 0f))
        //     {
        //         intersectionPoint = hit.point;
        //         // Используйте intersectionPoint для получения нужных координат
        //         // Например, intersectionPoint.x и intersectionPoint.z
                
        //     }
        // }
    }
}
