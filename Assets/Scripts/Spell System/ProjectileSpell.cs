using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(menuName = "Nekki.TestTask/SpellSystem/Projectile Spell", fileName = "New Projectile Spell")]
    public class ProjectileSpell : SpellBase
    {
        [SerializeField] private Projectile projectilePrefab;
        
        public override void Cast(Transform castTransform)
        {
            var projectile = Instantiate(projectilePrefab, castTransform.position, castTransform.rotation);
            projectile.Initialize(damage);
        }
    }
}