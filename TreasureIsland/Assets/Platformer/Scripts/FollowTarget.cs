
using UnityEngine;


    public class FollowTarget : MonoBehaviour // Скрипт следования камеры за целевым обектом(героем)
    {
        [SerializeField] Transform _target;
        [SerializeField] float _damping;
        void Update()
        {
            var destanation = new Vector3(_target.position.x, _target.position.y, transform.position.z); 
            transform.position = Vector3.Lerp(transform.position, destanation, Time.deltaTime * _damping); // Функци сглаживания перемещения
        }
    }

