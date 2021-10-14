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
    public class BathroomMiniGameUI : MonoBehaviour
    {
        private BathroomMiniGame miniGame;
        [SerializeField] private Slider urgencySlider;
        [SerializeField] private ColorSwapper colorSwapper;
        [SerializeField] private Image urgencyFillArea;
        public static bool RequireUIUpdate = false;
        private void Awake()
        {
            miniGame = GetComponent<BathroomMiniGame>();
        }
        private void Update()
        {
            UpdateSlider();
        }
        private void UpdateSlider()
        {
            if(urgencySlider.value != miniGame.GetUrgencyLevel())
                urgencySlider.value = miniGame.GetUrgencyLevel();
            urgencyFillArea.color = colorSwapper.GetCurrentColor();;
            if(miniGame.GetUrgencyLevel() >= 1)
            {
                colorSwapper.UpdateColor(colorSwapper.GetFillColor());
            }
            else
            {
                colorSwapper.UpdateColor(colorSwapper.GetMidColor());
            }
        }
    }
}