using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(menuName = "Pet.Survivor/SpellSystem/Projectile Spell", fileName = "ProjectileSpell")]
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