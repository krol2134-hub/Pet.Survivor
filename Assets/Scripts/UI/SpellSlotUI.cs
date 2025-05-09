using SpellSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    //TODO Update select key hint depend on input controls
    public class SpellSlotUI : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI iconNameText;
        [SerializeField] private TextMeshProUGUI previousButtonNameText;
        [SerializeField] private TextMeshProUGUI previousButtonText;

        private SpellController _spellController;

        public void UpdateSlotInfo(Sprite iconSprite, string iconName)
        {
            iconImage.sprite = iconSprite;
            iconNameText.text = iconName;
        }
    }
}