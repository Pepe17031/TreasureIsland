using System;
using UnityEngine;
using UnityEngine.Events;

namespace GoraTales.Components
{
    
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _action?.Invoke(other.gameObject); // ? -не равен нулю, аакшен в найстройках компонента
            }
        }
        
        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {
            
        }
    }
    
    

}