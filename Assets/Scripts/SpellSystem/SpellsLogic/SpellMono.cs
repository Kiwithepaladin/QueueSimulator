using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FillingGround.SpellSystem.Logic;
using FillingGround.SpellSystem.Visuals;
using FillingGround.SpellSystem.Interface;
using System.Linq;

namespace FillingGround.SpellSystem.Monos
{
    public class SpellMono : MonoBehaviour
    {
        [SerializeField] private Spell spell;
        [SerializeField] private SpellVisualsMono spellVisualsMono;
        [SerializeField] private KeyCode abilityKey;

        private void Awake()
        {
            if(spell != null)
            {
                spell.GetSpellCooldown().InitializeTimer();
            }
            if(spellVisualsMono != null)
            {
                spellVisualsMono.InitializeSpellContainer(spell.GetSpellVisuals(),spell.GetSpellElement().GetSpellElementVisuals());
            }
        }
        private void Update()
        {
            if(spell == null || spellVisualsMono == null)
                return;
            if(spellVisualsMono.GetSpellCooldownVisuals() != null)
            {
                spellVisualsMono.GetSpellCooldownVisuals().UpdateIndicator(spell);
            }
            spell.GetSpellCooldown().TickTimer();
            if(spell.SpellRequirmenet() && Input.GetKeyDown(abilityKey))
            {
                SpellMonoSupervisor.RequestGlobalCooldown = true;
                spell.ActiveSpell();
            }
        }
        public void RunGlobalCooldown()
        {
            if(spell.GetType().GetInterfaces().Contains(typeof(IGlobalCooldown)))
            {
                IGlobalCooldown iGCD = (IGlobalCooldown)spell;
                StartCoroutine(iGCD.GlobalCooldown());
            }
        }
        #region Getters
        public Spell GetSpell()
        {
            return spell;
        }
        #endregion
        // private void OnDisable()
        // {
        //     spell.spellGlobalCooldown.RemoveAllListeners();
        // }
    }
}
