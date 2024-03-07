using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static LightController instance;
    public Transform currentTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
