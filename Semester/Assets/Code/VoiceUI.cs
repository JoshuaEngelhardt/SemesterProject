using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle
{
    public class VoiceUI : MonoBehaviour
    {
        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
        }
        public void Worked()
        {
            image.color = Color.green;

        }

        public void Failed()
        {
            image.color = Color.red;
        }
    }
}
