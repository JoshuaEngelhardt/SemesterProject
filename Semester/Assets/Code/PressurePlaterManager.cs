using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class PressurePlaterManager : MonoBehaviour
    {
        public GameObject objectToActivate;
        public List<GameObject> currentPlates;

        void Update()
        {
            HashSet<GameObject> truePlates = new HashSet<GameObject>();
            foreach (GameObject plate in currentPlates)
            {
                if (plate.GetComponent<PressurePlate>().inUse == false)
                {
                    truePlates.Add(plate);
                 
                }
            }
            if(truePlates.Count == currentPlates.Count)
            {
                objectToActivate.SetActive(true);
            }
        }


    }
}
