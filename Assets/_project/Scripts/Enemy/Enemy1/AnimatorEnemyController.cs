using UnityEngine;

public class AnimatorEnemyController : MonoBehaviour
{
    private Animator _animator;
    private AIEnemy _aiEnemy;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _aiEnemy = GetComponentInParent<AIEnemy>();
    }

    private void FixedUpdate()
    {
        PlayingAnimation();
    }

    private void PlayingAnimation()
    {
        if(_aiEnemy.IsMoving == true && _animator.GetBool("IsMoving") == false)
            _animator.SetBool("IsMoving", true);
        if(_aiEnemy.IsMoving == false && _animator.GetBool("IsMoving") == true)
            _animator.SetBool("IsMoving", false);
    }   
}
