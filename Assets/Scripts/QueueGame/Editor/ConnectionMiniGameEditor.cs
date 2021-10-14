using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(ConnectionMiniGame))]
    public class ConnectionMiniGameEditor : MiniGameEditor
    {
        public override void OnInspectorGUI()
        {
            ConnectionMiniGame connectionMiniGame = (ConnectionMiniGame)target;
            base.OnInspectorGUI();

            if(GUILayout.Button("Lose Signal"))
            {
                connectionMiniGame.LoseSignal();
            }
            if(GUILayout.Button("Fill Signal"))
            {
                connectionMiniGame.FillSignal();
            }
        }
    }
    #endif
}
