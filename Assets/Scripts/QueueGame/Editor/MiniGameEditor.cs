using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(MiniGame)),CanEditMultipleObjects]
    public class MiniGameEditor : Editor 
    {
        SerializedProperty isFinishedProp;

        private void OnEnable() {
            isFinishedProp = serializedObject.FindProperty("isFinished");
        }
        public override void OnInspectorGUI()
        {
            MiniGame miniGame = (MiniGame)target;
            base.OnInspectorGUI();
            miniGame.SetActive(EditorGUILayout.Toggle("Is Mini Game Active: ", miniGame.IsActive()));
            GUILayout.BeginVertical();
            GUILayout.Label(isFinishedProp.boolValue.ToString());
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Finish MiniGame"))
            {
                miniGame.FinishMiniGame();
            }
            if(GUILayout.Button("Reset MiniGame"))
            {
                miniGame.Reset();
            }
            GUILayout.EndHorizontal();
        }
    }
    #endif
}