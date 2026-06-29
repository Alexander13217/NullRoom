using UnityEngine;

namespace Player
{
    public class AnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private StateHandler _state;

        private void OnEnable()
        {
            _state.StateChanged += UpdateAnimation;
        }

        private void OnDisable()
        {
            _state.StateChanged -= UpdateAnimation;
        }

        private void UpdateAnimation(State state)
        {
            if(state == State.Walking)
            {
                _animator.SetBool("IsMoving", true);
                return;
            }
            _animator.SetBool("IsMoving", false);
        }
    }
}

