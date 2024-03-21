using System.Collections;
using System.Collections.Generic;
using Puzzle;
using UnityEngine;

namespace Puzzle
{
    public class PressurePlate : MonoBehaviour
    {
        public bool inUse;

         void Start()
        {
            inUse = true;
        }

       public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<AppearableObject>() == true)
            {
                inUse = true;
                //print("1");
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<AppearableObject>() == true)
            {
                inUse = false;
                //print("2");
            }
        }

        void Update()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
            if(colliders.Length == 0) { 
                //print("2");
            }
        }


    }
}
