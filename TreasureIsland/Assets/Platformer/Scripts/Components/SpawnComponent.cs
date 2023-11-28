using UnityEngine;

namespace GoraTales.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] GameObject _prefab;
        
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instantiat = Instantiate(_prefab, _target.position, Quaternion.identity);
            instantiat.transform.localScale = _target.lossyScale;
        }
    }
}
