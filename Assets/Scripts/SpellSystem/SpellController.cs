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
        }

        public void Dispose () => _inputController.SpellCastPressed -= Cast;

        private void Cast() => _spells[_currentSpellIndex].Cast(_castTransform);
    }
}