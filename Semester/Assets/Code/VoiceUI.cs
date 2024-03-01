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
        private Image normalState;
        private Image workingState;

        private void Start()
        {
            instance = this;
        }
        public void Worked()
        {
            //normalState.gameObject.SetActive(false);
            //workingState.gameObject.SetActive(true);
            print("I did work!");
        }

 

        public void Failed()
        {
            
        }
    }
}
