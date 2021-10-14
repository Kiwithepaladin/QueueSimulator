using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FillingGround.SpellSystem.Logic;
using FillingGround.SpellSystem.Visuals;
using FillingGround.SpellSystem.Interface;
using System;
using System.Linq;
using UnityEngine.Events;

namespace FillingGround.SpellSystem.Monos
{
    public class SpellMonoSupervisor : MonoBehaviour, IHasteable
    {
        public static readonly float spellGlobalCooldownMin = 1;
        public static readonly float spellGlobalCooldownMax = 1.5f;
        public static float spellGlobalCooldownCurrent;
        public static bool isOnGloabalCooldown = false;
        public static bool RequestGlobalCooldown = false;
        [SerializeField] private float testGCDDuration;
        public static float globalCooldownDuration = 0f;
        [HideInInspector] public UnityEvent OnGlobalCooldown;
        [SerializeField] private List<SpellMono> spells;
        [Header("Haste")]
        [Range(1,150)] [SerializeField] private float hasteMax = 50;
        [Range(0,100)] [SerializeField] private float hasteMultiplier;
        [SerializeField] private float hastePrecentage;
        public float HasteMaxValue => hasteMax;
        public float HasteMultiplier { get => hasteMultiplier; set => hasteMultiplier = value; }
        public float HastePrecentage { get => hastePrecentage; set => hastePrecentage = ((value / HasteMaxValue) * 100); }
        private void Awake()
        {
            ResetGlobalCooldown();
            PopulateList();
        }
        void Update()
        {
            testGCDDuration = globalCooldownDuration;
            UpdateSpellCooldown();
            TickGlobalCooldown();
            foreach (SpellMono spell in spells)
            {
                if(typeof(IHasteable).IsAssignableFrom(spell.GetSpell().GetType()))
                {
                    spell.GetSpell().UpdateSpellCooldown();
                }
            }
            if(RequestGlobalCooldown)
            {
                foreach(SpellMono spell in spells)
                {
                    if(typeof(IGlobalCooldown).IsAssignableFrom(spell.GetSpell().GetType()))
                    {
                        StartGlobalCooldown();
                        spell.RunGlobalCooldown();
                    }
                }
                RequestGlobalCooldown = false;
            }
        }
        private void TickGlobalCooldown()
        {
            if(GetIsOnGlobalCooldown())
                globalCooldownDuration += Time.deltaTime;
        }
        private void PopulateList()
        {
            var spellMonos = GetComponents<SpellMono>();
            spells =  spellMonos.ToList();
        }
        public static void ResetGlobalCooldown()
        {
            globalCooldownDuration = 0;
        }
        public static float GetSpellGlobalCooldown()
        {
            return spellGlobalCooldownMax;
        }
        public bool GetIsOnGlobalCooldown()
        {
            return isOnGloabalCooldown;
        }
        public void SetIsOnGlobalCooldown(bool newIsOnGCD)
        {
            isOnGloabalCooldown = newIsOnGCD;
        }
        #region Invokers
        public void StartGlobalCooldown()
        {
            OnGlobalCooldown?.Invoke();
        }
        #endregion
        public float HasteReduction()
        {
            float globalCooldownCalc = spellGlobalCooldownMax / ((hastePrecentage / 100) + 1);
            return globalCooldownCalc < spellGlobalCooldownMin ? spellGlobalCooldownMin : globalCooldownCalc;
        }
        public void UpdateSpellCooldown()
        {
            HastePrecentage = HasteMultiplier;
            spellGlobalCooldownCurrent = HasteReduction();
        }
    }
}
