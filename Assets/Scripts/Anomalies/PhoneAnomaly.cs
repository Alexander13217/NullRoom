using System;
using UnityEngine;

namespace Anomaly
{
    public class PhoneAnomaly : BaseAnomaly
    {
        [SerializeField] private AudioClip _ringingClip;
        [SerializeField] private AudioClip _talkClip;

        public override event Action Deactivated;

        private Audio _audio;

        private void Awake()
        {
            _audio = new Audio(_source, _initClip);
        }

        public override void Activate()
        {
            gameObject.SetActive(true);
            _audio.PlayInit();
            _audio.Play(_ringingClip);
            StartTimer(5f);
        }
    }
}
