using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyType type;

        public EnemyType Type => type;
    }
}