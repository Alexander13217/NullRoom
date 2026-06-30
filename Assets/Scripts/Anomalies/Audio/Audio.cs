using UnityEngine;

namespace Anomaly
{
    public class Audio
    {
        private AudioSource _source;
        private AudioClip _initClip;

        public Audio(AudioSource source, AudioClip initClip)
        {
            _source = source;
            _initClip = initClip;
            _source.loop = true;
        }

        public void PlayInit()
        {
            _source.PlayOneShot(_initClip);
        }

        public void Play(AudioClip clip, bool loop = true)
        {
            _source.Stop();
            _source.loop = loop;
            _source.clip = clip;
            _source.Play();
        }
    }
}

