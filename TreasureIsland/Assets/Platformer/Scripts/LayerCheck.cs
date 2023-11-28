using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace GoraTales
{
    public class LayerCheck : MonoBehaviour
    {
        [SerializeField] LayerMask _layer;
        [SerializeField] bool _isTouchingLayer;
        Collider2D _collider;

        public bool IsTouchingLayer => _isTouchingLayer;

        void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        void OnTriggerStay2D(Collider2D other)
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layer);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
    }

}