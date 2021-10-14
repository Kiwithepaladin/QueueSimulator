using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FillingGround.QueueGame.MiniGames
{
    public class MiniGameSupervisior : MonoBehaviour
    {
        [SerializeField] private int simultaneousMiniGames;
        [SerializeField] private List<MiniGame> allMiniGames;
        [SerializeField] private List<MiniGame> activeMiniGames;
        private void Awake()
        {
            InitializeMiniGames();
        }
        private void Update()
        {
            if(!QueueSupervisor.isInQueue || QueueSupervisor.Defeated) {return;}
            if(activeMiniGames.Count < simultaneousMiniGames)
                StartNewMiniGame();
            CheckForFailure();
            RemoveUnactiveMiniGames();
            ResetFinishedMiniGames();   
        }
        private void StartNewMiniGame()
        {
            bool anyIsFinished = allMiniGames.Any((m) => !m.IsFinished() && !m.IsActive());
            if(!anyIsFinished)
            {
                return;
            }
            else
            {
                MiniGame newMiniGame = allMiniGames.Find((m) => !m.IsFinished() && !m.IsActive());
                if(!activeMiniGames.Contains(newMiniGame) && newMiniGame != null)
                {
                    activeMiniGames.Add(newMiniGame);
                    newMiniGame.Reset();
                    newMiniGame.SetActive(true);
                }
                return;
            }
        }
        private void RemoveUnactiveMiniGames()
        {
            var index = activeMiniGames.FindIndex(0,activeMiniGames.Count, (m) => !m.IsActive());
            if(index > -1)
            {
                activeMiniGames.RemoveAt(index);
                RemoveUnactiveMiniGames();
            }
            return;
        }
        private void ResetFinishedMiniGames()
        {
            var index = allMiniGames.FindIndex(0,allMiniGames.Count, (m) => m.IsFinished());
            if(index > -1)
            {
                allMiniGames[index].Reset();
                ResetFinishedMiniGames();
            }
            return;
        }
        private void InitializeMiniGames()
        {
            foreach (var miniGame in FindObjectsOfType<MiniGame>())
            {
                allMiniGames.Add(miniGame);
                miniGame.Reset();
            }
        }
        private void CheckForFailure()
        {
            if(!QueueSupervisor.isInQueue)
                return;
            foreach (var miniGame in allMiniGames)
            {
                if(miniGame.GetMiniGameResult() == MiniGameResult.Failure)
                {
                    QueueSupervisor.Defeated = true;
                }
            }
        }
        public void DecreaseSimultaneousMiniGames()
        {
            if(simultaneousMiniGames-1 >= 0)
            {
                if(activeMiniGames.Count > 0)
                    activeMiniGames[activeMiniGames.Count-1].Reset();
                simultaneousMiniGames--;
            }
            return;
        }
        public void IncreaseSimultaneousMiniGames()
        {
            if(activeMiniGames.Count+1 <= allMiniGames.Count)
            {
                simultaneousMiniGames++;
            }
            return;
        }
    }
}