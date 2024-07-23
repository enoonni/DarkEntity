using UnityEngine;
using UnityEngine.InputSystem;
using InputController;

namespace Gameplay.Player.Controller
{
    public class PlayerController
    {           
        private Camera _mainCamera;
        private CharacterController _characterController;
        private Transform _transformPlayer;
        private Vector3 _mousePoint;
        
        [SerializeField] private float _moveSpeed = 5;

        [SerializeField] private float _fallSpeed = 10;
        
        public PlayerController(Camera mainCamera,  CharacterController characterController, Transform transformPlayer)
        {
            _mainCamera = mainCamera;
            _characterController = characterController;
            _transformPlayer = transformPlayer;
        }  

        public void Move()
        {
            MovePlayer(InputSystemHandler.Instance.MoveDirection);
            Fall();
        }

        public void Rorate()
        {
            UpdateMousePoint();                
            RotatePlayer();
        }    
        
        private void MovePlayer(Vector2 MoveDirection)
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
            var dist = _mousePoint - _transformPlayer.position;
            Quaternion rotation = Quaternion.LookRotation(dist, _transformPlayer.TransformDirection(Vector3.up));
            _transformPlayer.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        }       
    }
}
