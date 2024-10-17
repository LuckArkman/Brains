#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PathFinds
{
    public class NodeController : EditorWindow
    {
        public Transform origin;
        
        [MenuItem("MPLopes/NodePointEditor")]
        private static void ShowWindow()
        {
            var window = GetWindow<NodeController>();
            window.titleContent = new GUIContent("NodePoint");
            window.Show();
        }

        private void OnGUI()
        {
            SerializedObject obj = new SerializedObject(this);
            EditorGUILayout.PropertyField(obj.FindProperty("origin"));
            if (origin is null)
            {
                EditorGUILayout.HelpBox("Please Assign NodePoint", MessageType.Warning);
            }

            if (origin != null)
            {
                EditorGUILayout.BeginVertical("box");
                CreateButtons();
                EditorGUILayout.EndVertical();
            }

            obj.ApplyModifiedProperties();
        }

        private void CreateButtons()
        {
            if (GUILayout.Button("create NodePoint")) CreateWaypoint();
            if(GUILayout.Button("create guid"))CreateGuidBefore();
            if(GUILayout.Button("ConnectPointsRight"))ConnectPointsAfter();
            if(GUILayout.Button("ConnectPointsLeft"))ConnectPointsLeft();
            if(GUILayout.Button("NodesLeft"))NodesLeft();
            if(GUILayout.Button("NodesRight"))NodesRight();
            if(GUILayout.Button("NodesClear"))NodesClear();
        }

        private void NodesClear()
        {
            List<Node> _nodes = new List<Node>();
            for (int i = 0; i < origin.transform.childCount; i++)
            {
                _nodes.Add(origin.transform.GetChild(i).GetComponent<Node>());
            }
            for (int i = 0; i < _nodes.Count; i++)
            {
                _nodes[i]._Nodes.Clear();
            }
        }

        private void ConnectPointsLeft()
        {
            List<Node> _nodes = new List<Node>();
            for (int i = 0; i < origin.transform.childCount; i++)
            {
                _nodes.Add(origin.transform.GetChild(i).GetComponent<Node>());
            }
            for (int i = _nodes.Count -1; i > 0; i--)
            {
                _nodes[i]._Nodes.Add(_nodes[--i]);
            }
        }

        private void NodesRight()
        {
            for (int i = 0; i < origin.transform.childCount; i++)
            {
                origin.transform.GetChild(i).GetComponent<Node>().Right = true;
            }
        }

        private void NodesLeft()
        {
            for (int i = 0; i < origin.transform.childCount; i++)
            {
                origin.transform.GetChild(i).GetComponent<Node>().Left = true;
            }
        }

        private void ConnectPointsAfter()
        {
            List<Node> _nodes = new List<Node>();
            for (int i = 0; i < origin.transform.childCount; i++)
            {
                _nodes.Add(origin.transform.GetChild(i).GetComponent<Node>());
            }
            for (int i = 0; i < _nodes.Count; i++)
            {
                _nodes[i]._Nodes.Add(_nodes[i+1]);
            }
        }

        private void CreateGuidBefore()
        {
            List<Node> _nodeList = new List<Node>();
            for (int i = 0; i < origin.transform.childCount; i++)
            {
                _nodeList.Add(origin.transform.GetChild(i).GetComponent<Node>());
            }
            _nodeList.ForEach(n => n._guid = Guid.NewGuid().ToString());
            
        }

        private void CreateWaypoint()
        {
            GameObject waypoint = new GameObject("NodePoint" + origin.childCount, typeof(Node));
            waypoint.transform.SetParent(origin, false);
            waypoint.transform.position += Vector3.zero;
            Node wayPoint = waypoint.GetComponent<Node>();
        }
    }
}
#endif