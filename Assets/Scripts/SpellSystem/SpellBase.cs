using UnityEngine;

namespace SpellSystem
{
    public abstract class SpellBase : ScriptableObject
    {
        [SerializeField] private float damage = 10f;
        
        public abstract void Cast(Transform castTransform);
    }
}