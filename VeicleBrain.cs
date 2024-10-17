using System;
using Atlants.Genetics;
using Atlants.PathFinds;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Brains
{
    [Serializable]
    public class VeicleBrain
    {
        public Quaternion _quaternion;
        public VeicleBrain(){}
        public int DNALength;
        public Node _node;
        public Node _nodePrevius;
        public float time = 0;
        public Vector3 rot = Vector3.zero;
        public float turn_Smooth = 0.025f;
        public float turn_Smooth_Time = 0.025f;
        public float turn_Smooth_angle = 0.025f;
        const float AvoidSpeed = 200;
        public float timeAlive, timeWalking;        
        public float distanceTravelled;
        public int previos;
        Vector3 startPosition;
        public float move, speed;
        public bool invert;
        public  float turn;
        public Walkable _walkable;
        public DNA dna;
        public bool seeGroup, walkable;
        Vector3 m_move;
        bool m_jump;

        public void OnUpdate(GameObject _gameObject)
        {
            if (_node != null)
            {
                seeGroup = Distance(_gameObject, _node) >= distanceTravelled;
                if (seeGroup)
                {
                    Vector3 targetDir = _node.transform.position - _gameObject.transform.position;
                    float angle = Vector3.SignedAngle(_gameObject.transform.forward, targetDir, Vector3.up);
                    _gameObject.transform.Rotate(Vector3.up, angle * turn_Smooth);
                    move = speed;
                }

                if (!seeGroup)
                {
                    if (_node._Nodes.Count == 0)
                    {
                        Debug.Log($"{_gameObject.transform.name} Node Not work");
                        return;
                    }

                    if (_node._Nodes.Find(x => x._guid == _node._guid) != null)
                    {
                        Debug.Log($"{_gameObject.transform.name} Node Not work");
                        return;
                    }

                    if (_node._Nodes.Count <= 1 && Distance(_gameObject, _node) <= distanceTravelled)
                        _node = _node._Nodes[0];
                    if (_node._Nodes.Count > 1 && Distance(_gameObject, _node) <= distanceTravelled)
                        _node = CheckNodeList(_node._Nodes[Random.Range(0, _node._Nodes.Count)]);
                }

                _gameObject.transform.Translate(0, 0, move * 0.1f, Space.Self);
            }
        }

        private Node CheckNodeList(Node nodeNode)
        {
            Node n = nodeNode;
            while (_nodePrevius != null && _nodePrevius._guid == n._guid)
            {
                n = _node._Nodes[Random.Range(0, _node._Nodes.Count)];
            }

            _nodePrevius = _node;
            return n;
        }

        private float Distance(GameObject _gameObject,Node node)
        => Vector3.Distance(_gameObject.transform.position, new Vector3(node.transform.position.x, _gameObject.transform.position.y, node.transform.position.z));
    }
}