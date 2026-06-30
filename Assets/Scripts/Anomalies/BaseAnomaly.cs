using System;
using System.Collections;
using UnityEngine;

namespace Anomaly
{
    public abstract class BaseAnomaly : MonoBehaviour
    {
        public event Action Deactivated;

        public abstract void Activate();
        public abstract IEnumerator StartTimer(float time);
    }
}

