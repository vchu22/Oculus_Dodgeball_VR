using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (DetectVRHeadset.VRMode)
        {
            // Vector3 scale = transform.scale;
            Debug.Log("Object scale: ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
