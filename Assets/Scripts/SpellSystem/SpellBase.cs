using UnityEngine;

namespace SpellSystem
{
    public abstract class SpellBase : ScriptableObject
    {
        [SerializeField] protected float damage = 10f;
        [SerializeField] private float cooldown = 1f;
        [SerializeField] private string displayName = "Fireball";
        [SerializeField] private Sprite icon;

        public float Cooldown => cooldown;
        public string Name => displayName;
        public Sprite Icon => icon;

        public abstract void Cast(Transform castTransform);
    }
}