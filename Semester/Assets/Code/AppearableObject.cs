using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

namespace Puzzle
{
    public class AppearableObject : MonoBehaviour
    {
        public Renderer objectRenderer;
        public Collider objectCollider;
        public Rigidbody _rigidBody;
        public static AppearableObject instance;

        void Start()
        {
            objectRenderer = GetComponent<Renderer>();
            objectCollider = GetComponent<Collider>();
            _rigidBody = GetComponent<Rigidbody>();
            instance = this;
        }

        public void Disappear()
        {
            _rigidBody.DOMove(transform.position + new Vector3(0, 5, 0), 1);
            //Invoke("Gone", 1);
            //objectRenderer.enabled = false;
            //objectCollider.enabled = false;
        }

        public void Gone()
        {
            objectRenderer.enabled = false;
            objectCollider.enabled = false;
        }

        public void Appear()
        {
            objectRenderer.enabled=true;
            objectCollider.enabled=true;
        }
    }
}
