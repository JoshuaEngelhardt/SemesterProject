using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class VoiceUI : MonoBehaviour
    {
        public static VoiceUI instance;
        private Image image;

        private void Start()
        {
            instance = this;
            image = GetComponent<Image>();
        }
        public void Worked()
        {
            //image.color = Color.green;     
            print("I did work!");
        }

 

        public void Failed()
        {
            image.color = Color.red;
        }
    }
}
