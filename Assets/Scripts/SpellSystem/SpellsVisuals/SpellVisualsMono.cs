using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FillingGround.SpellSystem.Visuals
{
    public class SpellVisualsMono : MonoBehaviour
    {
        [SerializeField] private Image spellBackgroundSR;
        [SerializeField] private Image spellIconSR;
        [SerializeField] private SpellCooldownVisualsMono spellCooldownVisuals;
        public void InitializeSpellContainer(Visuals newSpellVisuals, Visuals newSpellElementVisuals)
        {
            SetSpellBackground(newSpellVisuals.GetSpellSprite(),newSpellVisuals.GetSpellColor());
            SetSpellIcon(newSpellElementVisuals.GetSpellSprite(),newSpellElementVisuals.GetSpellColor());
        }
        #region Getters
        public SpellCooldownVisualsMono GetSpellCooldownVisuals()
        {
            return spellCooldownVisuals;
        }
        #endregion
        #region Setters
        public void SetSpellBackground(Sprite newSprite, Color newColor)
        {
            if(spellBackgroundSR != null)
            {
                spellBackgroundSR.sprite = newSprite;
                spellBackgroundSR.color = newColor;
            }
        }
        public void SetSpellIcon(Sprite newSprite, Color newColor)
        {
            if(spellIconSR)
            {
                spellIconSR.sprite = newSprite;
                spellIconSR.color = newColor;
            }
        }
        #endregion
    }
}
