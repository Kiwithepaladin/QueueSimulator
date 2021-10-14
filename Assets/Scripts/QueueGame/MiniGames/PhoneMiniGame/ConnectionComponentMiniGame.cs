using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    #endif
    [RequireComponent(typeof(ConnectionComponentMiniGameUI))]
    public class ConnectionComponentMiniGame : MonoBehaviour
    {
        [SerializeField] private ConnectionMiniGame miniGame;    
        [SerializeField] private int maxValue;
        [SerializeField] private int minValue;
        private ConnectionComponentMiniGameUI ui;
        private void Awake()
        {
            ui = GetComponent<ConnectionComponentMiniGameUI>();
            miniGame = GetComponentInParent<ConnectionMiniGame>();
        }
        void Update()
        {
            if(miniGame.connectionStength >= 6)
                ui.FullOpqueFillColor();
            else if(miniGame.connectionStength > maxValue)
                ui.FullOpaque();
            else if(miniGame.connectionStength == maxValue)
                ui.FadeHalf();
            else if(miniGame.connectionStength <= minValue)
                ui.FadeAll();
            else
                return;
        }
        public int GetMaxValue()
        {
            return maxValue;
        }
        public int GetMinValue()
        {
            return minValue;
        }
    }
}