using System;
using System.Collections;
using UnityEngine;

namespace Anomaly
{
    public abstract class BaseAnomaly : MonoBehaviour
    {
        [SerializeField] protected AudioSource _source;
        [SerializeField] protected AudioClip _initClip;

        public abstract event Action Deactivated;

        private Coroutine _timer = null;

        public abstract void Activate();

        protected void StartTimer(float time)
        {
            if(_timer != null)
            {
                throw new InvalidOperationException
                    ("The timer has already started.");
            }
            _timer = StartCoroutine(Timer(time));
        }

        protected void StopTimer()
        {
            if(_timer == null)
            {
                throw new InvalidOperationException
                    ("The timer has not started.");
            }
            StopCoroutine(_timer);
            _timer = null;
        }

        private IEnumerator Timer(float time)
        {
            yield return new WaitForSeconds(time);
            //Call lose event
        }
    }
}

