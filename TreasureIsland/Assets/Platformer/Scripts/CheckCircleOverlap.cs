using System;
using System.Collections.Generic;
using System.Linq;
using GoraTales.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace GoraTales
{
    public class CheckCircleOverlap: MonoBehaviour
    {
        [SerializeField] float _radius = 1f;
        [SerializeField] LayerMask _mask;
        [SerializeField] OnOverlapEvent _onOverlap;
        readonly Collider2D[] _interactionResult = new Collider2D[10];
        [SerializeField] string[] _tags;

        #if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            Handles.color = HandlesUtils.TransparentRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }
        #endif
        public void Check()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position, 
                _radius, 
                _interactionResult, 
                _mask);

            for (var i = 0; i < size; i++)
            {
                var overlapResult = _interactionResult[i];
                var isInTags = _tags.Any(tag => overlapResult.CompareTag(tag));
                if (isInTags)
                {
                    _onOverlap?.Invoke(overlapResult.gameObject);
                }
            }        
        }

        [Serializable]
        public class OnOverlapEvent : UnityEvent<GameObject>
        {
            
        }
        
    }
}
