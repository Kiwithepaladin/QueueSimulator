using System.Collections;
using System.Collections.Generic;
using FillingGround.QueueGame.ServerSide;
using Ink.Runtime;
using UnityEngine;

namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    #endif
    [RequireComponent(typeof(ConnectionMiniGameUI))]
    public class ConnectionMiniGame : MiniGame
    {
        [Range(0,6)] [SerializeField] public int connectionStength;
        [SerializeField] private Story currentStory;
        private bool inDialogue;  
        private bool isInternetFixed;
        private void Awake()
        {
            Server.OnTick +=delegate (object sender, OnTickEventArgs e) 
            {
                if(IsActive())
                    {
                    int chance = Random.Range(1,100);
                    if(chance > 75)
                    {
                        LoseSignal();
                    }
                    return;
                }
            };
        }
        public Story GetCurrentStory()
        {
            return currentStory;
        }
        public bool IsInternetFixed()
        {
            if(currentStory != null)
            {
                return isInternetFixed = (bool)currentStory.variablesState["isInternetFixed"];
            }
            else
            {
                Debug.LogWarning("Current story is null, if happends in runtime, contact the main developer");
                return isInternetFixed = false;
            }
        }
        public void SetCurrentStory(TextAsset inkJson)
        {
            currentStory = new Story(inkJson.text);
        }
        public bool InDialogue()
        {
            return inDialogue;
        }
        public void SetInDialogue(bool newValue)
        {
            inDialogue = newValue;
        }
        protected override void Update()
        {
            base.Update();
            if(!QueueSupervisor.isInQueue){return;}
            if(IsInternetFixed())
            {
                FinishMiniGame();
                result = MiniGameResult.Initialized;
            }
            if(connectionStength <= 0)
            {
                result = MiniGameResult.Failure;
            }
        }
        public void LoseSignal()
        {
            int newStrength = Random.Range(1,2);
            connectionStength -= newStrength;
        }
        public void FillSignal()
        {
            connectionStength = 6;
            result = MiniGameResult.Success;
        }
        public override void FinishMiniGame()
        {
            base.FinishMiniGame();
            FillSignal();
            isInternetFixed = false;
        }
        public void MakeChoice(int choiceIndex)
        {
            GetCurrentStory().ChooseChoiceIndex(choiceIndex);
        }
    }
}