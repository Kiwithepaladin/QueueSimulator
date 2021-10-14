using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FillingGround.QueueGame.Utilities
{
    [System.Serializable]
    public class ColorSwapper
    {
        [SerializeField] private Color fillColor;
        [SerializeField] private Color midColor;
        [SerializeField] private Color currentColor;
        public Color UpdateColor(Color newColor)
        {
            return currentColor = newColor;
        }
        public Color GetFillColor()
        {
            return fillColor;
        }
        public Color GetMidColor()
        {
            return midColor;
        }
        public Color GetCurrentColor()
        {
            return currentColor;
        }
    }
}