using Enemies;
using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(menuName = "Nekki.TestTask/SpellSystem/Aoe Spell", fileName = "New Aoe Spell")]
    public class AoeSpell : SpellBase
    {
        [SerializeField] private float radius = 5f;
        [SerializeField] private GameObject effectPrefab;
        [SerializeField] private LayerMask damageableLayerMask;

        private static readonly Collider[] _colliders = new Collider[20];
        
        public override void Cast(Transform castTransform)
        {
            Instantiate(effectPrefab, castTransform);

            ApplyDamage(castTransform);
        }

        private void ApplyDamage(Transform castTransform)
        {
            var overlapCount = Physics.OverlapSphereNonAlloc(castTransform.position, radius, _colliders, damageableLayerMask);
            for (var i = 0; i < overlapCount; i++)
            {
                var overlapGameObject = _colliders[i];
                if (overlapGameObject.TryGetComponent<IDamageable>(out var damageable)) 
                    damageable.ApplyDamage(damage);
            }
        }
    }
}