using System.Collections;
using System.Collections.Generic;
using FillingGround.SpellSystem.Enums;
using FillingGround.SpellSystem.Visuals;
using UnityEngine;

namespace FillingGround.SpellSystem.Logic
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "EmptySpellElement", menuName = "FillingSystem/SpellSystem/Logic/SpellElement", order = 0)]
    public class SpellElement : ScriptableObject
    {
        [SerializeField] private SpellElementType spellElementType;
        [SerializeField] private List<SpellDebuffType> spellDebuffTypes;
        [SerializeField] private SpellElementVisuals spellElementVisuals;
        #region Getters
        public SpellElementType GetElementType()
        {
            return spellElementType;
        }
        public List<SpellDebuffType> GetDebuffTypes()
        {
            return spellDebuffTypes;
        }
        public SpellElementVisuals GetSpellElementVisuals()
        {
            return spellElementVisuals;
        }
        #endregion
        #region Setters
        public void SetElementColor(SpellElementType newElementType)
        {
            spellElementType = newElementType;
        }
        #endregion
        #region Changers
        public void AddDebuffType(SpellDebuffType newDebuff)
        {
            spellDebuffTypes.Add(newDebuff);   
        }
        public void RemoveDebuffType(SpellDebuffType toRemoveDebuff)
        {
            spellDebuffTypes.Remove(toRemoveDebuff);
        }
        #endregion
    }
}
