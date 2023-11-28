using System;
using System.Collections;
using GoraTales.Components;
using UnityEngine;

namespace GoraTales.Creatures
{
    public class MobAi : MonoBehaviour
    {
        [SerializeField] LayerCheck _vision;
        [SerializeField] LayerCheck _canAttack;
        [SerializeField] float _alarmDealy = 0.5f;
        [SerializeField] float _attackColdown = 1f;
        [SerializeField] float _missHeroColdown = 1f;

        Coroutine _current;
        GameObject _target;
        SpawnListComponent _particles;
        Creature _creature;
        Animator _animator;
        static readonly int IsDeadKey = Animator.StringToHash("is-dead");
        bool _isDead;
        Patrol _patrol;
// ---------------------------------------------------- FUNCTION

        void Awake()
        {
            _particles = GetComponent<SpawnListComponent>();
            _creature = GetComponent<Creature>();
            _animator = GetComponent<Animator>();
            _patrol = GetComponent<Patrol>();
        }
        void Start()
        {
            StartState(_patrol.DoPatrol());
        }
        
        void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector2.zero);
            if (_current != null)
            {
                StopCoroutine(_current);
            }
            _current = StartCoroutine(coroutine);
        }

        void SetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            direction.y = 0;
            _creature.SetDirection(direction.normalized);
            
        }

        public void OnDie()
        {
            _isDead = true;
            _animator.SetBool(IsDeadKey, true);
            
            if (_current != null)
            {
                StopCoroutine(_current);
            }
        }
        public void OnHeroInVision(GameObject go)
        {
            if (_isDead) return;
            
            _target = go;
            StartState(AgroToHero());
        }
        
        // ---------------------------------------------------- STATES
        IEnumerator AgroToHero()
        {
            //_particles.Spawn("Exclamation");
            yield return new WaitForSeconds(_alarmDealy);
            StartState(GoToHero());
            
        }

        IEnumerator GoToHero()
        {
            while (_vision.IsTouchingLayer)
            {
                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }
                yield return null;
            }
            //_particles.Spawn("MissHero");
            yield return new WaitForSeconds(_missHeroColdown);
            StartState(_patrol.DoPatrol());
        }
        IEnumerator Attack()
        {
            while (_canAttack.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackColdown);
            }
            StartState(GoToHero());
        }

    }
}
