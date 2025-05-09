using System.Collections.Generic;
using UI;
using UnityEngine;

namespace SpellSystem
{
    public class SpellController 
    {
        private readonly SpellBase[] _spells;
        private readonly SpellSlotUI _spellSlotUI;
        private readonly Transform _spellParent;

        private readonly Dictionary<SpellBase, float> _castTimeBySpell = new(); 
        
        public SpellController(SpellBase[] spells, SpellSlotUI spellSlotUI,
            Transform spellParent)
        {
            _spells = spells;
            _spellSlotUI = spellSlotUI;
            _spellParent = spellParent;

            foreach (var spell in spells)
            {
                var defaultCastTime = Time.time + spell.Cooldown;
                _castTimeBySpell.Add(spell, defaultCastTime);
            }
        }

        public void Update()
        {
            UpdateSpells();
        }

        private void UpdateSpells()
        {
            foreach (var spell in _spells)
            {
                var spellTime = _castTimeBySpell[spell];

                var isCanCast = Time.time >= spellTime;
                if (isCanCast)
                {
                    spell.Cast(_spellParent.transform);
                    _castTimeBySpell[spell] = Time.time + spell.Cooldown;
                }
            }
        }
    }
}