using Atlants.Genetics;
using UnityEngine;
using Atlants.PathFinds;
using Random = UnityEngine.Random;
using System.Collections;

namespace Brains
{
    
    public class Brain : MonoBehaviour
    {
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
        public void OnStart()
        {
            dna = new DNA(DNALength, 3);
            
            StartCoroutine(RepeatAction());
        }

        private IEnumerator RepeatAction()
        {
            // Tempo de espera em segundos (0.02s = 20ms)
            WaitForSecondsRealtime waitTime = new WaitForSecondsRealtime(0.02f);
    
            while (Application.isPlaying)
            {
                OnUpdate();
                yield return waitTime;
            }
        }

        public void OnUpdate()
        {
            if(_node != null)seeGroup = Distance(_node) >= distanceTravelled;
            if (seeGroup && _node != null)
            {
                Vector3 targetDir = _node.transform.position - transform.position;
            Vector3 angle = Quaternion.LookRotation(targetDir).eulerAngles;
            rot = new Vector3
                (
                    Mathf.SmoothDampAngle(rot.x, angle.x, ref turn_Smooth_angle, turn_Smooth_Time),
                    Mathf.SmoothDampAngle(rot.y, angle.y, ref turn_Smooth_angle, turn_Smooth_Time),
                    Mathf.SmoothDampAngle(rot.z, angle.z, ref turn_Smooth_angle, turn_Smooth_Time)
                );
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, rot.y, 0.0f), turn_Smooth);
                move = speed;
                
            }

            if (!seeGroup)
            {
                if (_node._Nodes.Count == 0)
                {
                    Debug.Log($"{this.transform.name} Node Not work");
                    return;
                }

                if (_node._Nodes.Find(x => x._guid == _node._guid) != null)
                {
                    Debug.Log($"{this.transform.name} Node Not work");
                    return;
                }
                if (_node._Nodes.Count <= 1 && Distance(_node) <= distanceTravelled) _node = _node._Nodes[0];
                if (_node._Nodes.Count > 1 && Distance(_node) <= distanceTravelled)_node = CheckNodeList(_node._Nodes[Random.Range(0, _node._Nodes.Count)]);
            }
            this.transform.Translate(0, 0, move * 0.1f, Space.Self);
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

        private float Distance(Node node)
        => Vector3.Distance(transform.position, node.transform.position);
    }
}