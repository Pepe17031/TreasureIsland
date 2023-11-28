using System;
using UnityEngine;
using UnityEngine.Events;

namespace GoraTales
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] [Range(1, 30)] int _frameRate = 10;
        [SerializeField] UnityEvent<string> _onComplite;
        [SerializeField] AnimationClip[] _clips;

        SpriteRenderer _renderer;
        
        float _secPerFrame;
        float _nextFrameTime;
        int _currentFrame;
        bool _isPlaying = true;
        int _currentClip;
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>(); 
            _secPerFrame = 1f / _frameRate;
        }

        void OnBecameVisible()
        {
            enabled = _isPlaying;
        }

        void OnBecameInvisible()
        {
            enabled = false;
        }

        public void SetClip(string clipName)
        {
            for (var i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == clipName)
                {
                    _currentClip = i;
                    StartAnimation();
                    return;
                }
            }

            enabled = _isPlaying = false;
        }

        void StartAnimation()
        {
            _nextFrameTime = Time.time + _secPerFrame;
            _isPlaying = enabled = true;
            _currentFrame = 0;
        }
        void OnEnable()
        {
            _nextFrameTime = Time.time + _secPerFrame; //Время следующего кадра
        }

        void Update()
        {
            if (_nextFrameTime > Time.time) return; //Если вреям не пришло выход

            var clip = _clips[_currentClip];
            if (_currentFrame >= clip.Sprites.Length) // Анимация проигралась 1 цикл
            {
                if (clip.Loop)
                {
                    _currentFrame = 0; // Если цикл то заного
                }
                else
                {
                    enabled = _isPlaying = clip.AllowNextClip;
                    clip.OnComplite?.Invoke();
                    _onComplite?.Invoke(clip.Name);
                    if (clip.AllowNextClip)
                    {
                        _currentFrame = 0;
                        _currentClip = (int)Mathf.Repeat(_currentClip + 1, _clips.Length);
                    }
                }
                return;
            }
            _renderer.sprite = clip.Sprites[_currentFrame]; //Рендерим спрайт
            
            _nextFrameTime += _secPerFrame; //Получаем Следующую картинку
            _currentFrame++; //Увеличиваем индекс
        }

    }

    [Serializable]
    public class AnimationClip
    {
        [SerializeField] string _name;
        [SerializeField] Sprite[] _sprites;
        [SerializeField] bool _loop;
        [SerializeField] bool _allowNextClip;
        [SerializeField] UnityEvent _onComplite;

        public string Name => _name;
        public Sprite[] Sprites => _sprites;
        public bool Loop => _loop;
        public bool AllowNextClip => _allowNextClip;
        public UnityEvent OnComplite => _onComplite;
    }

}