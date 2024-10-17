namespace Brains
{
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using Atlants.Genetics;
    using Atlants.PathFinds;
    using UnityEngine;

public class Senssor : MonoBehaviour
    {
        public int DNALength;
        [SerializeField] const float senssorLenght = 2.5f;
        [SerializeField] const float frontSenssorStartingPoint = 1;
        [SerializeField] const float frontSideSenssorStartingPoint = 0.5f;
        [SerializeField] const float frontSenssorAngle = 40f;
        public int i = 0;
        public Vector3 target;
        public const float AvoidSpeed = 200;
        public float timeAlive, timeWalking;        
        public float distanceTravelled;
        public List<GameObject> eyes = new List<GameObject>();
        Vector3 FrontPosition;

        public float fielOfView;
        Vector3 startPosition;
        public float move, speed;
        public bool invert;
        public  float turn, right;
        public Walkable _walkable;
        public DNA dna;
        public bool seeGroup, walkable;
        Vector3 m_move;
        bool m_jump;
        void Start(){}

        void Update()
        {
            /*
            RaycastHit hit;
            if(Physics.Raycast(eyes[0].transform.position, eyes[0].transform.forward *2f, out hit))
            {
                Obstacle walkable = hit.transform.GetComponent<Obstacle>();
                if (walkable != null) seeGroup = false;
                if (walkable == null) seeGroup = true;                
            }
            if(Physics.Raycast(eyes[0].transform.position, eyes[0].transform.forward *2f, out hit))
            {
                _walkable = hit.transform.GetComponent<Walkable>();
                if (_walkable != null)
                {
                    walkable = _walkable.walk;
                    seeGroup = true;
                    turn = 0;
                    move = speed;

                }
                if (_walkable == null) walkable = false;                
            }
            if (!seeGroup)
            {
                if (dna.GetGene(1) == 0) right = 10f;
                if (dna.GetGene(1) == 1) right += 5f;
                if (dna.GetGene(1) == 2) right -= 5f;
                if (dna.GetGene(2) == 0) right = 10;
                if (dna.GetGene(2) == 1) right += 5f;
                if (dna.GetGene(2) == 2) right -= 5f;
                
            }
            if (!walkable)
            {
                if (dna.GetGene(1) == 0) turn = 180f;
                if (dna.GetGene(1) == 1) turn += 1f;
                if (dna.GetGene(1) == 2) turn -= 1f;
                if (dna.GetGene(2) == 0) turn = 180;
                if (dna.GetGene(2) == 1) turn += 1f;
                if (dna.GetGene(2) == 2) turn -= 1f;
                
            }
            if(walkable)transform.Translate(0, 0, speed * 0.1f, Space.Self);
            if (right != 0)
            {
                transform.position += transform.right * right * Time.deltaTime;
                right = 0;
            }
            this.transform.RotateAround(transform.position, transform.up, AvoidSpeed * Time.deltaTime * turn);
            */
        }
        public void Init(){}
    }
}