using UnityEngine;

namespace Player
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _runningSound;
        [SerializeField] private StateHandler _state;

        private void OnEnable()
        {
            _state.StateChanged += UpdateSound;
        }

        private void OnDisable()
        {
            _state.StateChanged -= UpdateSound;
        }

        private void Awake()    
        {
            _source.loop = true;
            _source.clip = _runningSound;
        }
        
        private void UpdateSound(State state)
        {
            if(state == State.Walking)
            {
                _source.Play();
                return;
            }
            _source.Stop();
        }
    }
}
