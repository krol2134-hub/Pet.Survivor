using UnityEngine;

namespace SpellSystem
{
    [CreateAssetMenu(menuName = "Nekki.TestTask/SpellSystem/Aoe Spell", fileName = "New Aoe Spell")]
    public class AoeSpell : SpellBase
    {
        [SerializeField] private float radius = 5f;
        [SerializeField] private GameObject effectPrefab;
        
        public override void Cast(Transform castTransform)
        {
            Instantiate(effectPrefab, castTransform);
        }
    }
}