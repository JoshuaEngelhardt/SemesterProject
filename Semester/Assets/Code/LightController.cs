using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Transform character;

    public Light lightComponent;

    public static LightController instance;
    void Start()
    {
        lightComponent = GetComponent<Light>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.position.x,character.position.y + 1.5f,character.position.z);
    }

 
}
