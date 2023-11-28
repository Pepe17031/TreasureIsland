using UnityEngine;

namespace GoraTales.Components
{
    public class SitchComponent : MonoBehaviour
    {

        [SerializeField] Animator _animator;
        [SerializeField] bool _state;
        [SerializeField] string _animationKey;
        
        public void Switch() //Смена булевог значения тригера анимации
        {
            _state = !_state;
            _animator.SetBool(_animationKey, _state);
        }

        [ContextMenu("Switch")]
        public void SwitchIt()
        {
            Switch();
        }
    }
}
