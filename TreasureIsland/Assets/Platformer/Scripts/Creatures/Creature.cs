using System;
using GoraTales.Components;
using GoraTales.Components.Audio;
using UnityEngine;
using UnityEngine.Serialization;

namespace GoraTales.Creatures
{
    public class Creature : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] float _speed; 
        [SerializeField] protected float _jumpSpeed;
        [SerializeField] float _damageVelocity;
        [SerializeField] int _damage;
        [SerializeField] bool _invertScale;
        [Header("Checkers")]
        [SerializeField] protected LayerMask _groundLayer;
        [SerializeField] LayerCheck _groundCheck;
        [SerializeField] CheckCircleOverlap _attackRange;
        [SerializeField] protected SpawnListComponent _particles;
        protected Rigidbody2D Rigidbody;
        protected Vector2 Direction;
        protected Animator Animator;
        protected bool IsGrounded;
        protected PlaySoundsComponent Sounds;
        bool _isJumping;

        static readonly int IsGroundKey = Animator.StringToHash("is-groud");
        static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velocity");
        static readonly int IsRunningKey = Animator.StringToHash("is-running");
        static readonly int Hit = Animator.StringToHash("hit");
        static readonly int IsAttackKey = Animator.StringToHash("attack");

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            Sounds = GetComponent<PlaySoundsComponent>();
        }
        
        public void SetDirection(Vector2 direction)
        {
            Direction = direction.normalized;
        }

        protected virtual void Update()
        {
            IsGrounded = _groundCheck.IsTouchingLayer;
        }
        
        void FixedUpdate()
        {
            var xVelocity = Direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            Rigidbody.velocity = new Vector2(xVelocity, yVelocity);
            
            Animator.SetBool(IsGroundKey, IsGrounded);
            Animator.SetFloat(VerticalVelocityKey, Rigidbody.velocity.y);
            Animator.SetBool(IsRunningKey, Direction.x != 0);

            UpdateSpriteDirection();
        }
        
        protected virtual float CalculateYVelocity()
        {
            var yVelocity = Rigidbody.velocity.y;
            var isJumpPressing = Direction.y > 0;

            if (IsGrounded)
            {
                _isJumping = false;
            }
            
            if (isJumpPressing)
            {
                _isJumping = true;
                
                var isFalling = Rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;

            } else if (Rigidbody.velocity.y > 0 && _isJumping) // Прыжок отпущен
            {
                yVelocity *= 0.85f;
            }
            return yVelocity;
        }

        protected virtual float CalculateJumpVelocity(float yVelocity)
        {
            if (IsGrounded)
            {
                yVelocity += _jumpSpeed;
                DoJumpVfx();
            }
            return yVelocity;
        }
        
        protected void DoJumpVfx()
        {
            _particles.Spawn("Jump");
            Sounds.Play("Jump");
        }
        
        private void UpdateSpriteDirection()
        {
            var multipler = _invertScale ? -1 : 1;
            
            if (Direction.x > 0)
            {
                transform.localScale = new Vector3(multipler, 1 , 1);
            }
            else if (Direction.x < 0)
            {
                transform.localScale = new Vector3(-1 * multipler, 1, 1);
                
            }
        }
        
        public virtual void TakeDamage()
        {
            Animator.SetTrigger(Hit);
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _damageVelocity);
        }
        
        public virtual void Attack()
        {
            Animator.SetTrigger(IsAttackKey);
            Sounds.Play("Melee");
        }
        
        public void OnDoAttack()
        {
            _attackRange.Check();
        }
    }
}
