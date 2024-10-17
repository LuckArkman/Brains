using System;
using System.Collections.Generic;
using UnityEngine;

namespace PathFinds
{
    public class Node : MonoBehaviour, ISerializationCallbackReceiver
    {
        public List<Node> _Nodes = new List<Node>();
        public string _guid = "";

        public bool Left, Right;

        private void OnDrawGizmos()
        {
            if (!Left && !Right)
            {
                Gizmos.DrawSphere(this.transform.position, 0.5f);
                _Nodes.ForEach(x =>
                {
                    Gizmos.DrawLine(this.transform.position, x.transform.position);
                });
            }
            if (!Left && Right)
            {
                Color color = Color.green;
                Gizmos.DrawSphere(this.transform.position, 0.5f);
                _Nodes.ForEach(x =>
                {
                    Gizmos.DrawLine(this.transform.position, x.transform.position);
                });
            }
            if (Left && !Right)
            {
                Gizmos.DrawCube(this.transform.position, new Vector3(0.5f,0.5f,0.5f));
                _Nodes.ForEach(x =>
                {
                    Gizmos.DrawLine(this.transform.position, x.transform.position);
                });
            }
        }

        public void OnBeforeSerialize()
        {
            if (string.IsNullOrEmpty(_guid)) _guid = Guid.NewGuid().ToString();
        }

        public void OnAfterDeserialize(){}
    }
}