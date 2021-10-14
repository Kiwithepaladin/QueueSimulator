using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FillingGround.QueueGame.ServerSide
{
    [Serializable]
    public class Server : MonoBehaviour
    {
        public static event EventHandler<OnTickEventArgs> OnTick;
        public const int serverLoad = 2500;
        private const float serverTickSpeedMax = 2f;
        private const int addPlayersMax = 7;
        private const int playersKickMax = 4;
        private const int playerGiveUp = 4;
        [SerializeField] private List<Queue> loggedInPlayers;
        [SerializeField] private int tick;
        private float tickTimer;
        private QueueSupervisor queueSupervisor;
        [HideInInspector] [SerializeField] private int amountToKick;
        private void Awake()
        {
            Application.runInBackground = true;
            loggedInPlayers = new List<Queue>(serverLoad);
            queueSupervisor = GetComponent<QueueSupervisor>();
            OnTick += delegate (object sender, OnTickEventArgs e) {
                var skip = UnityEngine.Random.Range(-5,addPlayersMax);
                var kicked = UnityEngine.Random.Range(-playersKickMax,playersKickMax);
                var gaveUp = UnityEngine.Random.Range(-playerGiveUp,playerGiveUp);
                if(skip < 0)
                {
                    return;
                }
                for (int i = 0; i < skip; i++)
                {
                    if(loggedInPlayers.Count < serverLoad)
                    {
                        Accept(queueSupervisor.queuedPlayers[0]);
                    }
                    else
                    {
                        Decline();
                    }
                }
                if(tick % 3 == 0)
                {
                    KickRandom(kicked);
                }
                if(tick % 5 == 0)
                {
                    var index = UnityEngine.Random.Range(0,queueSupervisor.queuedPlayers.Count);
                    for (int i = 0; i < gaveUp; i++)
                    {
                        if(index != QueueSupervisor.playersPosition)
                            GiveUp(queueSupervisor.queuedPlayers[index]);
                    }
                }
                QueueSupervisor.playersPosition = UpdatePlayerIndex();};
        }
        void Update()
        {
            if(QueueSupervisor.playersPosition <= -1 || QueueSupervisor.Defeated)
                return;
            ServerTick();
            CheckVictory();
        }

        private bool CheckVictory()
        {
            return QueueSupervisor.playersPosition <= -1;
        }
        private void ServerTick()
        {
            if(QueueSupervisor.isInQueue)
            {
                tickTimer += Time.deltaTime;
                if (tickTimer > serverTickSpeedMax)
                {
                    tickTimer -= serverTickSpeedMax;
                    tick++;
                    OnTick?.Invoke(this, new OnTickEventArgs { tick = tick });
                }
            }  
        }
        public void KickRandom(int kickAmount)
        {
            if(amountToKick > loggedInPlayers.Count)
            {
                amountToKick = loggedInPlayers.Count;
            }
            for (int i = 0; i < kickAmount; i++)
            {
                loggedInPlayers.RemoveAt(UnityEngine.Random.Range(0,loggedInPlayers.Count));
            }
        }
        public void WinGame()
        {
            if(loggedInPlayers.Count < serverLoad)
            {
                Accept(queueSupervisor.queuedPlayers[QueueSupervisor.playersPosition]);
            }
        }
        private void GiveUp(Queue player)
        {
            queueSupervisor.queuedPlayers.Remove(player);
        }
        private int UpdatePlayerIndex()
        {
            return queueSupervisor.queuedPlayers.FindIndex(0,queueSupervisor.queuedPlayers.Count,(p) => p.GetQueuerType() == QueuerType.Player);
        }
        private void Accept(Queue newPlayer)
        {
            loggedInPlayers.Add(newPlayer);
            queueSupervisor.RemoveFromQueue(newPlayer); 
        }
        private void Decline()
        {
           Debug.Log("Players Declined!");
        }
        private void Kick(Queue playerToKick)
        {
            loggedInPlayers.Remove(playerToKick);
        }
    }
}