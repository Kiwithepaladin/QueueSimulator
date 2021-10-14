using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FillingGround.SpellSystem.Monos;


namespace FillingGround.SpellSystem.Visuals
{
    public class SpellGlobalCooldownVisuals : MonoBehaviour
    {
        [SerializeField] private Slider spellGlobalCooldownSlider;
        private void Update()
        {
            UpdateGCDSlider();
        }
        private void UpdateGCDSlider()
        {
            if (spellGlobalCooldownSlider.value != SpellMonoSupervisor.globalCooldownDuration)
                spellGlobalCooldownSlider.value = SpellMonoSupervisor.globalCooldownDuration;
            if(spellGlobalCooldownSlider.maxValue != SpellMonoSupervisor.spellGlobalCooldownCurrent)
                spellGlobalCooldownSlider.maxValue = SpellMonoSupervisor.spellGlobalCooldownCurrent;
        }
    }
}
