using System;
using UnityEngine;
using UnityEngine.Events;

namespace GoraTales.Components
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _action;
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _action?.Invoke(other.gameObject); 
            }
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {
            
        }
        
        
    }
}
