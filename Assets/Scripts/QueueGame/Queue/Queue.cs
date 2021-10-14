using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FillingGround.QueueGame
{
    [Serializable]
    public class Queue
    {
        [SerializeField] private string playerGUID;
        [SerializeField] private QueuerType queuerType;

        public void SetQueuerType(QueuerType type)
        {
            queuerType = type;
        }
        public Queue()
        {
            GenerateGuid();
            queuerType = QueuerType.NPC;
        }

        public string GenerateGuid()
        {
           return playerGUID = Guid.NewGuid().ToString();
        }
        public QueuerType GetQueuerType()
        {
            return queuerType;
        }   
    }
}