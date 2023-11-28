using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoraTales.Components
{

    public class DestriyObjectComponent : MonoBehaviour
    {
        [SerializeField] GameObject _objecttodestroy;
        
        public void DestroyObject()
        {
            Destroy(_objecttodestroy);
        }
    }
    
}