using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(BathroomMiniGame))]
    public class BathroomMiniGameEditor : MiniGameEditor
    {
        public override void OnInspectorGUI()
        {
            BathroomMiniGame miniGame = (BathroomMiniGame)target;
            base.OnInspectorGUI();
            if(GUILayout.Button("Empty Urgency"))
            {
                miniGame.EmptyUrgency();
            }
            if(GUILayout.Button("Fill Urgency"))
            {
                miniGame.FillUrgency();
            }
        }
    }
    #endif
}
