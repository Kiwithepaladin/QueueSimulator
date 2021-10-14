using System.Collections;
using System.Collections.Generic;
using FillingGround.QueueGame.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    #endif
    public class ConnectionComponentMiniGameUI : MonoBehaviour
    {        
        private RawImage componentImage;
        [SerializeField] private ColorSwapper colorSwapper;
        private void Awake() 
        {
            componentImage = GetComponent<RawImage>();
        }
        private void Update()
        {
            if(!QueueSupervisor.isInQueue)
                return;
            if(componentImage.color != colorSwapper.GetCurrentColor())
                componentImage.color = colorSwapper.GetCurrentColor();
        }
        public void FadeHalf()
        {
            colorSwapper.UpdateColor(colorSwapper.GetMidColor());
            componentImage.color = new Color(componentImage.color.r,componentImage.color.g,componentImage.color.b,0.5f);
        }
        public void FadeAll()
        {
            colorSwapper.UpdateColor(colorSwapper.GetMidColor());
            componentImage.color = new Color(componentImage.color.r,componentImage.color.g,componentImage.color.b,0f);
        }
        public void FullOpaque()
        {
            colorSwapper.UpdateColor(colorSwapper.GetMidColor());
            componentImage.color = new Color(componentImage.color.r,componentImage.color.g,componentImage.color.b,1f);
        }
        public void FullOpqueFillColor()
        {
            colorSwapper.UpdateColor(colorSwapper.GetFillColor());
            componentImage.color = new Color(componentImage.color.r,componentImage.color.g,componentImage.color.b,1f);
        }

    }
}