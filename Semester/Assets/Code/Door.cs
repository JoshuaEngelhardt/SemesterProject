using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class Door : MonoBehaviour
    {

        Animator animator;

        public string Password;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            animator.SetTrigger("Open");
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}