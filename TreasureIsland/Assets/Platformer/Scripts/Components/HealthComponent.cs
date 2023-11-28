using UnityEngine;
using UnityEngine.Events;

namespace GoraTales.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] int _health;
        [SerializeField] UnityEvent _onDamage;
        [SerializeField] UnityEvent _onDie;
        [SerializeField] UnityEvent _onHeal;


        public void ModifyHealth(int healthDelta)
        {
            _health += healthDelta;
            
            if (healthDelta < 0)
            {
                _onDamage?.Invoke();
            }
            if (healthDelta > 0)
            {
                _onHeal?.Invoke();
            }
            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
    }
}

