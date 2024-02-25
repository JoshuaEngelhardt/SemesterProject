using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class AppearableObject : MonoBehaviour
    {
        private Renderer objectRenderer;
        public static AppearableObject instance;

        void Start()
        {
            objectRenderer = GetComponent<Renderer>();
            instance = this;
        }

        public void Disappear()
        {
            objectRenderer.enabled = false;
        }
       
        public void Appear()
        {
            objectRenderer.enabled=true;
        }
    }
}
