using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FillingGround.SpellSystem.Logic
{
    [System.Serializable]
    public class SpellCooldown
    {
        [SerializeField] private bool spellReady;
        [Range(0,100)] [SerializeField] private float spellCooldownMax = 20;
        [Range(0,100)] [SerializeField] private float spellCooldownMin = 0;
        [Range(0,100)] [SerializeField] private float spellBaseCooldown;
        [SerializeField] private float spellCooldown;
        private float spellCooldownTimer;

        public void TickTimer()
        {
            if(!IsSpellReady())
                spellCooldownTimer -= Time.deltaTime;
        }
        public void ResetSpellTimer()
        {
            spellCooldownTimer = spellCooldown;
        }
        public void InitializeTimer()
        {
            spellCooldownTimer = 0;
        }
        public bool IsSpellReady()
        {
            return spellReady = spellCooldownTimer <= spellCooldownMin;
        }
        public float GetSpellCooldownTimer()
        {
            return spellCooldownTimer;
        }
        public float GetSpellCooldown()
        {
            return spellCooldown;
        }
        public float GetSpellCooldownMax()
        {
            return spellCooldownMax;
        }
        public float GetSpellBaseCooldown()
        {
            return spellBaseCooldown;
        }
        public float GetSpellCooldownMin()
        {
            return spellCooldownMin;
        }
        public void SetSpellCooldown(float newSpellCooldown)
        {
            if(newSpellCooldown <= spellCooldownMin)
            {
                spellCooldown = spellCooldownMin;
            }
            else if(newSpellCooldown > spellCooldownMax)
            {
                spellCooldown = spellCooldownMax;
            }
            else
            {
                spellCooldown = newSpellCooldown;
            }
        }
    }
}