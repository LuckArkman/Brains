using System.Collections.Generic;
using UnityEngine;

namespace PathFinds
{
    public class RaycastFromEditorCamera : MonoBehaviour
    {
        public Camera _Camera;
        public Vector3 hitposition;
        public List<Vector3> _pointStat = new List<Vector3>();
        public GameObject _positions;        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = _Camera.ScreenPointToRay(mousePosition);
                RaycastHit hit;                
                if (Physics.Raycast(ray, out hit))
                {
                    hitposition = hit.point;
                    GameObject waypoint = new GameObject("NodePoint", typeof(Node));
                    waypoint.transform.SetParent(_positions.transform, false);
                    waypoint.transform.position = hit.point;
                    Node wayPoint = waypoint.GetComponent<Node>();
                    _pointStat.Add(waypoint.transform.position);
                }
            }
        }
        
        [ContextMenu(nameof(OnAddPoints))]
        void OnAddPoints()
        {
            for (int i = 0; i < _pointStat.Count; i++)
            {
                GameObject waypoint = new GameObject("NodePoint" + i, typeof(Node));
                waypoint.transform.SetParent(_positions.transform, false);
                waypoint.transform.position = _pointStat[i];
            }
        }
    }
}