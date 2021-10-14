using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FillingGround.QueueGame.ServerSide;

namespace FillingGround.QueueGame
{
    [RequireComponent(typeof(Server))]
    [RequireComponent(typeof(QueueSupervisorUI))]
    
    public class QueueSupervisor : MonoBehaviour
    {
        private const int queueSizeMax = 10000;
        public List<Queue> queuedPlayers;
        [SerializeField] private int playerPos;
        public static int playersPosition;
        public static bool isInQueue = false;
        public static bool Defeated;

        private void Awake()
        {
            Defeated = false;
        }
        private void Update()
        {
            if(!isInQueue || Defeated)
                return;
            playerPos = playersPosition;
        }
        private void GenerateInitialPositionInQueue()
        {
            playersPosition = Random.Range(5000,queuedPlayers.Count);
            queuedPlayers[playersPosition].SetQueuerType(QueuerType.Player);
        }
        public void LeaveQueue()
        {
            isInQueue = false;
        }
        public void StartNewQueue()
        {
            isInQueue = true;
            queuedPlayers.Clear();
            queuedPlayers = new List<Queue>();
            int randomQueueStartPosition = Random.Range(5000, queueSizeMax);

            for (int i = 0; i < randomQueueStartPosition; i++)
            {
                queuedPlayers.Add(new Queue());
            }
            GenerateInitialPositionInQueue();
        }
        public void RemoveFromQueue(Queue player)
        {
            queuedPlayers.Remove(player);
        }
    }
}