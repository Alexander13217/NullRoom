using UnityEngine;

namespace Player
{
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Movement _movement;

        private void Update()
        {
            _animator.SetBool("IsMoving", _movement.IsMoving);
        }
    }
}

