using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.Threading.Tasks;
using Atlants.PathFinds;
using UnityEngine;
using System.Collections;
using Photon.Pun;

namespace Brains
{
    public enum MyEnum
    {
        none,
        spawn,
    }
    public class NpcController : MonoBehaviour
    {
        public int number;
        public Node _Node;
        public MyEnum _myEnum;

        public List<GameObject> _Brains = new List<GameObject>();
        public List<Brain> _BrainInScene = new List<Brain>();

        public void OnStart()
        {
            if(_Brains.Count > 0)OnAsyncNPC();
        }
        
        private void Update()
        {
            if (_myEnum == MyEnum.spawn)
            {
                _myEnum = MyEnum.none;
                if (number < _Brains.Count)
                {
                    string name = _Brains[number].name;
                    GameObject brain = PhotonNetwork.Instantiate(name, this.transform.position, Quaternion.identity);
                    brain.GetComponent<Brain>()._node = _Node;
                    _BrainInScene.Add(brain.GetComponent<Brain>());
                    number++;
                    
                }
                if (number == _Brains.Count)
                {
                    string name = _Brains[_Brains.Count - 1].name;
                    GameObject brain = PhotonNetwork.Instantiate(name, this.transform.position, Quaternion.identity);
                    brain.GetComponent<Brain>()._node = _Node;
                    _BrainInScene.Add(brain.GetComponent<Brain>());
                    number++;
                }
                if (number > _Brains.Count)
                {
                    string name = _Brains[_Brains.Count - 1].name;
                    GameObject brain = PhotonNetwork.Instantiate(name, this.transform.position, Quaternion.identity);
                    brain.GetComponent<Brain>()._node = _Node;
                    _BrainInScene.Add(brain.GetComponent<Brain>());
                    number++;
                }
            }
        }

        private async void OnAsyncNPC()
        {
            while (number < _Brains.Count)
            {
                await Task.Delay(5000);
                _myEnum = MyEnum.spawn;
            }
            Debug.Log("Spawn Complete");
            await Task.CompletedTask;
        }
        [ContextMenu(nameof(CreateGuidBefore))]
        private void CreateGuidBefore()
        {
            List<Node> _nodeList = new List<Node>();
            for (int i = 0; i < this.transform.childCount; i++)
            {
                _nodeList.Add(this.transform.GetChild(i).GetComponent<Node>());
            }
            _nodeList.ForEach(n => n._guid = Guid.NewGuid().ToString());
            
        }
    }
}