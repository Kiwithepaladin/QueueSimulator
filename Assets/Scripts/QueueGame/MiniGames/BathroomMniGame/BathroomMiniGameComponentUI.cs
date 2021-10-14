using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FillingGround.QueueGame.MiniGames
{
    public class BathroomMiniGameComponentUI : MonoBehaviour
    {
        BathroomMiniGameComponent  component;
        [SerializeField] private Button componentButton;
        private void Awake()
        {
            component = GetComponent<BathroomMiniGameComponent>();
            componentButton = GetComponent<Button>();
        }
        void Update()
        {
            if(!component.IsButtonHeld()) {return;}
        }
    }
}