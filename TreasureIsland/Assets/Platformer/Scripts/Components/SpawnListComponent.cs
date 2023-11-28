using System;
using UnityEngine;

namespace GoraTales.Components
{
    public class SpawnListComponent: MonoBehaviour
    {
        [SerializeField] SpawnData[] _swawners;
        public void Spawn(string id)
        {
            foreach (var data in _swawners)
            {
                if (data.Id == id)
                {
                    data.Component.Spawn();
                    break;
                }
            }
        }
    }
    [Serializable]
    public class SpawnData
    {
        public string Id;
        public SpawnComponent Component;
    }
}
