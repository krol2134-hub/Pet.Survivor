using UnityEngine;

namespace SpellSystem
{
    public class SpellController : MonoBehaviour
    {
        [SerializeField] private SpellBase[] spells;

        private int _currentSpellIndex;
        
        public void Cast(Transform castTransform)
        {
            spells[_currentSpellIndex].Cast(transform);
        }
    }
}