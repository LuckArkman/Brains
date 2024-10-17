using UnityEngine;

namespace PathFinds
{
    public class Walkable : MonoBehaviour
    {
        void Start()
        {
            OnTag();
        }

        void OnTag()
        {
            this.gameObject.transform.tag = "Walkable";
        }
    }
}