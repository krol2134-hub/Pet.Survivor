using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private NavMeshAgent agent;

        public EnemyType Type => type;

        private IAttackEnemyTarget _target;
        
        public void Initialize(IAttackEnemyTarget target) => _target = target;

        private void Update() => TryMoveToTarget();

        private void TryMoveToTarget()
        {
            if (_target != null)
                agent.SetDestination(_target.Position);
        }
    }
}