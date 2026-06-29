using System;
using UnityEngine;

namespace Player
{
    public class StateHandler : MonoBehaviour
    {
        [SerializeField] private Movement _move;

        public event Action<State> StateChanged;

        private State _current = State.Idle;

        private void Update()
        {
            ChangeState();
        }

        private void ChangeState()
        {
            State newState = _move.IsMoving ? State.Walking : State.Idle;

            if (newState == _current)
            {
                return;
            }
            _current = newState;
            StateChanged?.Invoke(_current);
        }
    }
}

