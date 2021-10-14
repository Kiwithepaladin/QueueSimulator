using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(MiniGameSupervisior)),CanEditMultipleObjects]
    public class MiniGameSupervisiorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            MiniGameSupervisior miniGameSupervisior = (MiniGameSupervisior)target;
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Increase MiniGames"))
            {
                miniGameSupervisior.IncreaseSimultaneousMiniGames();
            }
            if(GUILayout.Button("Decrease MiniGames"))
            {
                miniGameSupervisior.DecreaseSimultaneousMiniGames();
            }
            GUILayout.EndHorizontal();

        }
    }
    #endif
}