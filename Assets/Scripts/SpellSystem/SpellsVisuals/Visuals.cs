using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FillingGround.SpellSystem.Visuals
{
    public abstract class Visuals : ScriptableObject
    {
            [SerializeField] private Color spellColor;
            [SerializeField] private Sprite spellSprite;
            public Color GetSpellColor()
            {
                return spellColor;
            }
            public void SetSpellColor(Color newElementColor)
            {
                spellColor = newElementColor;
            }
            public Sprite GetSpellSprite()
            {
                return spellSprite;
            }
    }
}