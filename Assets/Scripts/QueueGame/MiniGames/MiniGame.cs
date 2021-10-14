using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FillingGround.QueueGame.MiniGames
{
    public class MiniGame : MonoBehaviour
    {
        protected bool isActive;
        [SerializeField] [HideInInspector] private bool isFinished;
        [SerializeField] protected MiniGameResult result;
        protected virtual void Update()
        {
            if(IsFinished())
                return;
        }
        public bool IsFinished()
        {
            return isFinished;
        }
        public bool IsActive()
        {
            return isActive;
        }
        public void SetActive(bool newValue)
        {
            isActive = newValue;
        }
        public virtual void Disable()
        {
            if(IsActive())
                this.gameObject.SetActive(false);
        }
        public virtual void FinishMiniGame()
        {
            SetActive(false);
            isFinished = true;
        }
        public virtual void Reset()
        {
            result = MiniGameResult.Initialized;
            isFinished = false;
            isActive = false;
        }
        public MiniGameResult GetMiniGameResult()
        {
            return result;
        }
    }
}