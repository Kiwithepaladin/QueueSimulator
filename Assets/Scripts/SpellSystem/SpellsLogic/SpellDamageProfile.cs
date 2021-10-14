using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FillingGround.SpellSystem.Enums;

namespace FillingGround.SpellSystem.Logic
{
    [CreateAssetMenu(fileName = "EmptySpellDamageProfile", menuName = "FillingSystem/SpellSystem/Logic/SpellDamageProfile", order = 0)]
    public class SpellDamageProfile : ScriptableObject 
    {
        [SerializeField] private SpellDamageType spellDamageProfile;
        [SerializeField] private int damage;
    }
}
