using System;
using System.Collections;
using GoraTales.Components;
using UnityEngine;
using UnityEngine.UI;

namespace GoraTales.Creatures
{
    public class Hero : Creature
    {
        [SerializeField] CheckCircleOverlap _interactionCheck;
        [SerializeField] LayerCheck _wallCheck;
        
        [SerializeField] float _slamDownVelocity;
        [SerializeField] float _interactionRadius;
        
        [SerializeField] RuntimeAnimatorController _armed;
        [SerializeField] RuntimeAnimatorController _disarmed;
        [Space] [Header("Particles")]
        [SerializeField] ParticleSystem _hitParticles;
        [SerializeField] Text _coinsText;
        static readonly int IsDeadKey = Animator.StringToHash("is-dead");


        
        bool _allowDoubleJump;
        bool _isOnWall;
        
        [SerializeField] bool _isArmed;
        [SerializeField] int _coins = 0;
        float _defaultGravityScale;
        
        protected override void Awake()
        {
            base.Awake();
            _defaultGravityScale = Rigidbody.gravityScale;
        }
        
        
        void Start()
        {
            UpdateHeroWeapon(_isArmed);
        }
        public void AddCoins()
        {
            _coins++;
        }
        
        protected override void Update()
        {
            base.Update();
            _coinsText.text = _coins.ToString() + "$ KLAY";
            if (_wallCheck.IsTouchingLayer && Direction.x == transform.localScale.x)
            {
                _isOnWall = true;
                Rigidbody.gravityScale = 0;
            }
            else
            {
                _isOnWall = false;
                Rigidbody.gravityScale = _defaultGravityScale;
            }
        }
        
        protected override float CalculateYVelocity()
        {
            var isJumpPressing = Direction.y > 0;

            if (IsGrounded || _isOnWall)
            {
                _allowDoubleJump = true;
            }
            if (!isJumpPressing && _isOnWall)
            {
                return 0f;
            }
            return base.CalculateYVelocity();
        }
        
        protected override float CalculateJumpVelocity(float yVelocity)
        {
            if (!IsGrounded && _allowDoubleJump)
            {
                DoJumpVfx();
                _allowDoubleJump = false;
                return _jumpSpeed;
            }
            return base.CalculateJumpVelocity(yVelocity);
        }
        
        public override void TakeDamage()
        {

            base.TakeDamage();
            if (_coins > 0)
            {
                SpawnCoins();
            }
            
        }
        public void Interact()
        {
            _interactionCheck.Check();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            
            if (other.gameObject.tag == "Ground")
            {

                var contact = other.contacts[0];
                if (contact.relativeVelocity.y >= _slamDownVelocity)
                {

                    _particles.Spawn("SlamDown");
                }
            }
        }
        
        public override void Attack()
        {
            if (!_isArmed) return;
            base.Attack();
        }
        
        public void ArmHero()
        {
            _isArmed = true;
            UpdateHeroWeapon(_isArmed); 
        }
        
        public void Die()
        {
            Animator.SetBool(IsDeadKey, true);
        }
        
        void UpdateHeroWeapon(bool isArmed)
        {
            if (isArmed)
            {
                Animator.runtimeAnimatorController = _armed;
            }
            else
            {
                Animator.runtimeAnimatorController = _disarmed;
            }
        }
        
        void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(_coins, 1); //Сколько монет выкинуть
            _coins -= numCoinsToDispose;
            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);
            
            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

    }
}