using UnityEngine;

namespace SpellSystem
{
    public abstract class SpellBase : ScriptableObject
    {
        [SerializeField] protected float damage = 10f;
        [SerializeField] private string displayName = "Fireball";
        [SerializeField] private Sprite icon;

        public string Name => displayName;
        public Sprite Icon => icon;
        
        public abstract void Cast(Transform castTransform);
    }
}