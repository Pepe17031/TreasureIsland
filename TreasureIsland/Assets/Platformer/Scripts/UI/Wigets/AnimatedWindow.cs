using UnityEngine;

namespace GoraTales.UI
{
    public class AnimatedWindow : MonoBehaviour
    {
        Animator _animator;

        static readonly int Show = Animator.StringToHash("Show");
        static readonly int Hide = Animator.StringToHash("Hide");

        void Start()
        {
            _animator = GetComponent<Animator>();
            
            _animator.SetTrigger(Show);
        }

        public void Close()
        {
            _animator.SetTrigger(Hide);
        }

        public virtual void OnCloseAnimationComplite()
        {
            Destroy(gameObject);
        }
    }
}
