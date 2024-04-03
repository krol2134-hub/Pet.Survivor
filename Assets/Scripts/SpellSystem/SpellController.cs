using Player;
using UI;
using UnityEngine;

namespace SpellSystem
{
    public class SpellController
    {
        private readonly SpellBase[] _spells;
        private readonly PlayerInputController _inputController;
        private readonly SpellSlotUI _spellSlotUI;
        
        private readonly Transform _castTransform;
        
        private int _currentSpellIndex;

        private int CurrentSpellIndex
        {
            get => _currentSpellIndex;
            set
            {
                _currentSpellIndex = value;
                UpdateCurrentSpellSlot();
            }
        }

        public SpellController(SpellBase[] spells, PlayerInputController inputController, SpellSlotUI spellSlotUI, Transform castTransform)
        {
            _spells = spells;
            _inputController = inputController;
            _spellSlotUI = spellSlotUI;

            _castTransform = castTransform;
        }

        public void Enable()
        {
            _inputController.SpellCastPressed += Cast;
            _inputController.SpellPreviousPressed += SelectPreviousSpell;
            _inputController.SpellNextPressed += SelectNextSpell;
        }
        
        public void Disable()
        {
            _inputController.SpellCastPressed -= Cast;
            _inputController.SpellPreviousPressed -= SelectPreviousSpell;
            _inputController.SpellNextPressed -= SelectNextSpell;
        }

        private void Cast()
        {
            var currentSpell = _spells[CurrentSpellIndex];
            currentSpell.Cast(_castTransform);
        }

        private void SelectPreviousSpell()
        {
            if (CurrentSpellIndex == 0)
                return;

            CurrentSpellIndex--;
        }

        private void SelectNextSpell()
        {
            if (CurrentSpellIndex == _spells.Length - 1)
                return;

            CurrentSpellIndex++;
        }

        private void UpdateCurrentSpellSlot()
        {
            var currentSpell = _spells[CurrentSpellIndex];

            _spellSlotUI.UpdateSlotInfo(currentSpell.Icon, currentSpell.Name);
        }
    }
}