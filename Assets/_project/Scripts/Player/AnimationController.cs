using UnityEditor.Animations;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
   private Animator _animator;

   private void Awake()
   {
        _animator = GetComponent<Animator>();
   }

   private void FixedUpdate()
   {
      PlayAnimation(GetVectorDirection());
   }

   private Vector2 GetVectorDirection()
   {
      var directrion = InputSystemHandler.Instance.MoveDirection;
      Quaternion rotation = Quaternion.Euler(0, PlayerController.Instance.TransformPlayer.rotation.eulerAngles.y, 0);
      directrion = rotation * directrion;
      return directrion;
   }

   private void PlayAnimation(Vector2 direction)
   {        
      _animator.SetFloat("MoveX", direction.x);
      _animator.SetFloat("MoveY", direction.y);
   }
}
