using System;
using Player;
using UnityEngine;

namespace SpellSystem
{
    public class SpellController : IDisposable
    {
        private readonly SpellBase[] _spells;
        private readonly PlayerInputController _inputController;
        
        private readonly Transform _castTransform;
        
        private int _currentSpellIndex;
        
        public SpellController(SpellBase[] spells, PlayerInputController inputController, Transform castTransform)
        {
            _spells = spells;
            _inputController = inputController;

            _castTransform = castTransform;
            
            _inputController.SpellCastPressed += Cast;
            _inputController.SpellPreviousPressed += SelectPreviousSpell;
            _inputController.SpellNextPressed += SelectNextSpell;
        }

        public void Dispose ()
        {
            _inputController.SpellCastPressed -= Cast;
            _inputController.SpellPreviousPressed -= SelectPreviousSpell;
            _inputController.SpellNextPressed -= SelectNextSpell;
        }

        private void Cast()
        {
            var currentSpell = _spells[_currentSpellIndex];
            currentSpell.Cast(_castTransform);
        }

        private void SelectPreviousSpell()
        {
            if (_currentSpellIndex == 0)
                return;

            _currentSpellIndex--;
        }

        private void SelectNextSpell()
        {
            if (_currentSpellIndex == _spells.Length - 1)
                return;

            _currentSpellIndex++;
        }
    }
}