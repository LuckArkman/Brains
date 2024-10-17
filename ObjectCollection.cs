using System.Collections.Generic;
using Atlants.PathFinds;
using UnityEngine;

namespace Brains
{
    public class ObjectCollection : MonoBehaviour
    {
        public List<Transform> _tansfoms = new List<Transform>();
        public List<Obstacle> _Obstacles = new List<Obstacle>();

        [ContextMenu(nameof(GetObjects))]
        void GetObjects()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                _tansfoms.Add(transform.GetChild(i));
            }
        }
        [ContextMenu(nameof(AddCompoents))]
        void AddCompoents()
        {
            _tansfoms.ForEach(x => { x.gameObject.AddComponent<Obstacle>(); });
            _tansfoms.ForEach(o => _Obstacles.Add(o.GetComponent<Obstacle>()));
        }
    }
}