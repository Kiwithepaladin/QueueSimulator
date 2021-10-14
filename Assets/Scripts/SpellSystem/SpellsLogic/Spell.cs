using System.Collections;
using System.Collections.Generic;
using FillingGround.SpellSystem.Visuals;
using UnityEngine;
using UnityEngine.Events;
using FillingGround.SpellSystem.Interface;

namespace FillingGround.SpellSystem.Logic
{
    public abstract class Spell : ScriptableObject
    {
        [SerializeField] private string spellName;
        [SerializeField] private SpellCooldown spellCooldown;
        [SerializeField] private SpellElement spellElement;
        [SerializeField] private int spellManaCost;
        [SerializeField] private SpellVisuals spellVisuals;
        [SerializeField] private SpellDamageProfile spellProfile;
        #region Getters
        public string GetSpellName()
        {
            return spellName;
        }
        public SpellElement GetSpellElement()
        {   
            return spellElement;
        }
        public SpellCooldown GetSpellCooldown()
        {
            return spellCooldown;
        }
        public SpellVisuals GetSpellVisuals()
        {
            return spellVisuals;
        }
        #endregion
        #region  AbstractMethods
        public abstract void ActiveSpell();
        public abstract bool SpellRequirmenet();
        public abstract void CreateSpell();
        public abstract void UpdateSpellCooldown();
        #endregion
    }
}
