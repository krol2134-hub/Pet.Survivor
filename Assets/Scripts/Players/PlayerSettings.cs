using HealthSystem;
using SpellSystem;
using UnityEngine;

namespace Players
{
    [CreateAssetMenu(menuName = "Pet.Survivor/Player Settings", fileName = "PlayerSettings")]
    public class PlayerSettings : HealthSettings
    {
        [SerializeField] private SpellBase[] spells;
        [SerializeField] private float speed = 3f;

        public SpellBase[] Spells => spells;
        public float Speed => speed;
    }
}