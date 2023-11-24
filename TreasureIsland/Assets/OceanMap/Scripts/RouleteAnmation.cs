using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GoraTales
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class RouleteAnmation : MonoBehaviour
    {
        [SerializeField] float _frameRate;
        [SerializeField] Sprite[] _sprites;

        SpriteRenderer _renderer;
        float _secondsPerFrame;
        int _currentSpriteIndex;
        float _nextFrameTime;
        bool _isOn = true;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secondsPerFrame = 1f / _frameRate; // Частота кадров
            _nextFrameTime = Time.time + _secondsPerFrame; //Время следующего кадра
        }

        void OnEnable()
        {
            _secondsPerFrame = 1f / _frameRate; // Частота кадров
            _nextFrameTime = Time.time + _secondsPerFrame; // Время следующего кадра

            // Запускаем корутину, чтобы вызвать StopAnination через 3 секунды
            StartCoroutine(DelayedStopAnimation());
        }

        IEnumerator DelayedStopAnimation()
        {
            yield return new WaitForSeconds(3f);
            StopAnination(Random.Range(0, _sprites.Length));
        }

        void Update()
        {
            if (_nextFrameTime > Time.time) return; //Если вреям не пришло выход

            if (_isOn == true)
            {
                _renderer.sprite = _sprites[Random.Range(0, _sprites.Length)]; //Рендерим спрайт
                _nextFrameTime += _secondsPerFrame; //Получаем Следующую картинку
            } else return;
            
        }

        public void StopAnination(int value)
        {
            _isOn = false;
            _renderer.sprite = _sprites[value]; //Рендерим спрайт по входящему номеру
        }

    }

}