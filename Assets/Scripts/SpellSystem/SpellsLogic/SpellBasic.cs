using System.Collections;
using System.Collections.Generic;
using FillingGround.SpellSystem;
using UnityEngine;
using FillingGround.SpellSystem.Monos;
using FillingGround.SpellSystem.Interface;
using System;


namespace FillingGround.SpellSystem.Logic
{
    [CreateAssetMenu(fileName = "EmptyBasicSpell", menuName = "FillingSystem/SpellSystem/Logic/Spell", order = 0)]
    [Serializable]
    public class SpellBasic : Spell, IGlobalCooldown, IHasteable
    {
        [Header("Haste")]
        [Range(0,10)] [SerializeField] private float hasteMax = 5;
        [Range(0,100)] [SerializeField] private float hasteMultiplier;
        [SerializeField] private float hastePrecentage;
        public float HasteMaxValue => hasteMax;
        public float HasteMultiplier { get => hasteMultiplier; set => hasteMultiplier = value; }
        public float HastePrecentage { get => hastePrecentage; set => hastePrecentage = ((value / HasteMaxValue) * 100); }
        public override void ActiveSpell()
        {
            GetSpellCooldown().ResetSpellTimer();
            Debug.Log(GetSpellName() + " Used!");
        }
        public override bool SpellRequirmenet()
        {
            return GetSpellCooldown().IsSpellReady() && !SpellMonoSupervisor.isOnGloabalCooldown;
        }
        public override void CreateSpell()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerator GlobalCooldown()
        {
            SpellMonoSupervisor.isOnGloabalCooldown = true;
            yield return new WaitForSeconds(SpellMonoSupervisor.spellGlobalCooldownCurrent);
            SpellMonoSupervisor.ResetGlobalCooldown();
            SpellMonoSupervisor.isOnGloabalCooldown = false;
        }
        public float HasteReduction()
        {
            float spellCooldownCalc = hasteMax / ((hastePrecentage / 100) + 1);
            return spellCooldownCalc < 0 ? 0 : spellCooldownCalc;
        }
        public override void UpdateSpellCooldown()
        {
            HastePrecentage = HasteMultiplier;
            GetSpellCooldown().SetSpellCooldown(GetSpellCooldown().GetSpellBaseCooldown()-HasteReduction());
        }
    }
}
