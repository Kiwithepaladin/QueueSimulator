using System.Collections;
using System.Collections.Generic;
using FillingGround.QueueGame.ServerSide;
using UnityEngine;


namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    #endif
    [RequireComponent(typeof(BathroomMiniGameUI))]
    public class BathroomMiniGame : MiniGame
    {
        [SerializeField] [Range(0,1)] private float urgencyLevel;
        private void Awake() 
        {
            Server.OnTick +=delegate (object sender, OnTickEventArgs e) 
            {
                if(IsActive())
                {
                    int chance = Random.Range(1,100);
                    if(chance > 80)
                    {
                        IncreaseUrgencyRandom();
                    }
                    return;
                }
            };
        }
        public override void Reset()
        {
            base.Reset();
            urgencyLevel = 1;
        }
        protected override void Update()
        {
            base.Update();
            if(BathroomMiniGameUI.RequireUIUpdate)
            {
                ReduceUrgencyRandom();
                if(urgencyLevel >= 0.95f)
                {
                    FinishMiniGame();
                    result = MiniGameResult.Success;
                }
                BathroomMiniGameUI.RequireUIUpdate = false;
            }
        }
        public override void FinishMiniGame()
        {
            base.FinishMiniGame();
            FillUrgency();
        }
        public void IncreaseUrgencyRandom()
        {
            var reduction = Random.Range(0f,0.2f);
            if((urgencyLevel - reduction) < 0)
                urgencyLevel = 0;
            else
            {
                urgencyLevel -= Random.Range(0f,0.2f);   
            }
        }
        public void ReduceUrgencyRandom()
        {
            var addition = Random.Range(0.1f,0.2f);
            if((urgencyLevel + addition) < 1)
                urgencyLevel += addition;
            else
            {
                urgencyLevel = 1;
            }
        }
        public float EmptyUrgency()
        {
            result = MiniGameResult.Failure;
            return urgencyLevel = 0;
        }
        public float FillUrgency()
        {
           result = MiniGameResult.Success;
           return urgencyLevel = 1;
        }
        public float GetUrgencyLevel()
        {
            return urgencyLevel;
        }
    }
}