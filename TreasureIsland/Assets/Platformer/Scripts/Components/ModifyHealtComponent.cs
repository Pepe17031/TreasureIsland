using UnityEngine;
using UnityEngine.Serialization;

namespace GoraTales.Components
{
    public class ModifyHealtComponent : MonoBehaviour
    {
        [FormerlySerializedAs("_damage")]
        [SerializeField] int _hpDelta;

        public void Apply(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.ModifyHealth(_hpDelta);
            }
        }
    }
}
