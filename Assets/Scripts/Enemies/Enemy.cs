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
        
        public void Initialize(IAttackEnemyTarget target)
        {
            _target = target;

            MoveToTarget();
        }

        private void MoveToTarget() => agent.SetDestination(_target.Position);
    }
}