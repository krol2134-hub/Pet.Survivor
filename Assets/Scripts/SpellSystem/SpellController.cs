using System.Collections;
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
        
        private readonly MonoBehaviour _castBehaviour;
        
        private int _currentSpellIndex;

        private bool _isCooldown;

        private int CurrentSpellIndex
        {
            get => _currentSpellIndex;
            set
            {
                _currentSpellIndex = value;
                UpdateCurrentSpellSlot();
            }
        }

        public SpellController(SpellBase[] spells, PlayerInputController inputController, SpellSlotUI spellSlotUI, MonoBehaviour castBehaviour)
        {
            _spells = spells;
            _inputController = inputController;
            _spellSlotUI = spellSlotUI;

            _castBehaviour = castBehaviour;
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
            if (_isCooldown)
                return;
            
            var currentSpell = _spells[CurrentSpellIndex];
            currentSpell.Cast(_castBehaviour.transform);
            _castBehaviour.StartCoroutine(StartCooldown(currentSpell.Cooldown));

        }

        private IEnumerator StartCooldown(float cooldown)
        {
            _isCooldown = true;
            
            yield return new WaitForSeconds(cooldown);
            
            _isCooldown = false;
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