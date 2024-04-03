using System;
using HealthSystem;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemySettings settings;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private HealthSystem.HealthSystem healthSystem;

        public event Action<Enemy> Dead;
        
        public EnemyType Type => settings.Type;

        private IAttackEnemyTarget _target;
        
        public void Initialize(IAttackEnemyTarget target)
        {
            _target = target;
            agent.speed = settings.Speed;
        }

        private void OnEnable() => healthSystem.Dead += HealthSystemDeadHandler;

        private void OnDisable() => healthSystem.Dead -= HealthSystemDeadHandler;

        private void HealthSystemDeadHandler() => Die();

        private void Update()
        {
            if (_target == null)
                return;
            
            MoveToTarget();
            TryApplyDamageToTarget();
        }

        public void ApplyDamage(float applyDamage) => healthSystem.ApplyDamage(applyDamage);

        private void Die()
        {
            Dead?.Invoke(this);
            Destroy(gameObject);
        }

        private void MoveToTarget() => agent.SetDestination(_target.Position);

        private void TryApplyDamageToTarget()
        {
            var targetPosition = _target.Position;
            var currentPosition = transform.position;
            targetPosition.y = 0;
            currentPosition.y = 0;
            
            var distanceToTarget = Vector3.Distance(targetPosition, currentPosition);
            var enoughDistanceForAttack = distanceToTarget <= settings.RadiusForDamageTarget;
            if (enoughDistanceForAttack)
            {
                _target.ApplyDamage(settings.Damage);
                Die();
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_target != null)
                Gizmos.DrawWireSphere(transform.position, settings.RadiusForDamageTarget);
        }
#endif
    }
}