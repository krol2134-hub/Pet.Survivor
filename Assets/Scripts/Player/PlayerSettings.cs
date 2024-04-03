using SpellSystem;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Nekki.TestTask/Player Settings", fileName = "New Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private SpellBase[] spells;
        [SerializeField] private float speed = 3f;

        public SpellBase[] Spells => spells;
        public float Speed => speed;
    }
}