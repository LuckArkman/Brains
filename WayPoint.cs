using System.Collections.Generic;
using UnityEngine;

namespace PathFinds
{

    public class WayPoint : MonoBehaviour
    {
        public List<WayPoint> previus = new List<WayPoint>();
        public List<WayPoint> next = new List<WayPoint>();

        [Range(0.0f, 10.0f)]
        public float waypointWidth;
        public bool Left, Right;
    }
}
