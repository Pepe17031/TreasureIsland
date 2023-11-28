using System;
using UnityEngine;

namespace GoraTales.Components.Audio
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        [SerializeField] AudioSource _source;
        [SerializeField] AudioData[] _sounds;

        public void Play(string id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;
                _source.PlayOneShot(audioData.clip);
                break;
            }
        }
        
        [Serializable]
        public class AudioData
        {
            [SerializeField] string _id;
            [SerializeField] AudioClip _clip;

            public string Id => _id;
            public AudioClip clip => _clip;
        }
        
    }
}
