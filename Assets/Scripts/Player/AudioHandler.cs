using UnityEngine;

namespace Player
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private Movement _move;
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _runningSound;

        private void Awake()
        {
            _source.loop = true;
        }

        private void Update()
        {
            WalkSound();
        }

        private void WalkSound()
        {
            if (_move.IsMoving)
            {
                if(_source.isPlaying == false)
                {
                    _source.clip = _runningSound;
                    _source.Play();
                    return;
                }
                return;
            }
            _source.Stop();
        }
    }
}
