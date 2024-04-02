using UnityEngine;

namespace SpellSystem
{
    public abstract class SpellBase : ScriptableObject
    {
        [SerializeField] protected float damage = 10f;
        
        public abstract void Cast(Transform castTransform);
    }
}