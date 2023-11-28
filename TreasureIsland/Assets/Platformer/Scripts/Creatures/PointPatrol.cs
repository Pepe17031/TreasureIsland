using System;
using System.Collections;
using UnityEngine;

namespace GoraTales.Creatures
{
    public class PointPatrol : Patrol
    {
        [SerializeField] Transform[] _points;
        [SerializeField] float _treshold = 1f;
        Creature _creature;
        int _destanationPointIndex;
        void Awake()
        {
            _creature = GetComponent<Creature>();
        }

        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (IsOnPoint())
                {
                    _destanationPointIndex = (int)Mathf.Repeat(_destanationPointIndex + 1, _points.Length);
                }
                var direction = _points[_destanationPointIndex].position - transform.position;
                direction.y = 0;
                _creature.SetDirection(direction.normalized);
                yield return null;
            }
        }
        bool IsOnPoint()
        {
            return (_points[_destanationPointIndex].position - transform.position).magnitude < _treshold;
        }
    }
}
