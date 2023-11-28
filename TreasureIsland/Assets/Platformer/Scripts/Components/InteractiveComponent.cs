using UnityEngine;
using UnityEngine.Events;

namespace GoraTales.Components
{
    public class InteractiveComponent : MonoBehaviour
    {
        [SerializeField] UnityEvent _action;

        public void Interact()
        {
            _action?.Invoke();
        }
    }
}
