using System;
using System.Collections;
using UnityEngine;

namespace Anomaly
{
    public class PhoneAnomaly : BaseAnomaly, IInteractable
    {
        [SerializeField] private AudioClip _ringingClip;
        [SerializeField] private AudioClip _talkClip;

        public override event Action Deactivated;

        private Audio _audio;
        private string _clue;
        private bool _isDiactivating = true;

        private void Awake()
        {
            _audio = new Audio(_source, _initClip);
            _clue = "Press the 'E' key to answer a phone call.";
            Activate();
        }

        public override void Activate()
        {
            gameObject.SetActive(true);
            _isDiactivating = false;
            _audio.PlayInit();
            _audio.Play(_ringingClip);
            StartTimer(5f);
        }

        public void Interact()
        {
            if (_isDiactivating == true) return;
            StartCoroutine(Deactivate());
        }

        public string GetClue()
        {
            return _clue;
        }

        private IEnumerator Deactivate()
        {
            _isDiactivating = true;
            StopTimer();
            _audio.Play(_talkClip, false);
            yield return new WaitForSeconds(_talkClip.length);
            Deactivated?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
