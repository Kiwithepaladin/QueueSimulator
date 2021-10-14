using System.Collections;
using System.Collections.Generic;
using FillingGround.SpellSystem.Logic;
using UnityEngine;
using UnityEngine.UI;


namespace FillingGround.SpellSystem.Visuals
{
    [System.Serializable]
    public class SpellCooldownVisualsMono : MonoBehaviour
    {
        [SerializeField] private Image spellCooldownIndicator;
        public void UpdateIndicator(Spell spell)
        {
            if(spellCooldownIndicator != null)
            {
                spellCooldownIndicator.sprite = spell.GetSpellVisuals().GetSpellSprite();
                spellCooldownIndicator.fillAmount = spell.GetSpellCooldown().GetSpellCooldownTimer() / spell.GetSpellCooldown().GetSpellCooldown();
            }
        }
    }
}
