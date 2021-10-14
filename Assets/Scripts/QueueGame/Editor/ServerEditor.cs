using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FillingGround.QueueGame.ServerSide
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(Server))]
    public class ServerEditor : Editor {

        SerializedProperty amountKickProp;
        void OnEnable()
        {
            amountKickProp = serializedObject.FindProperty("amountToKick");
        }
        public override void OnInspectorGUI() 
        {

            Server server = (Server)target;
            base.OnInspectorGUI();
            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("Win Game"))
            {
                server.WinGame();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(amountKickProp ,new GUIContent("Amount"));
            if(GUILayout.Button("Kick Random Player"))
            {
                server.KickRandom(amountKickProp.intValue);
            }
            EditorGUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
}
