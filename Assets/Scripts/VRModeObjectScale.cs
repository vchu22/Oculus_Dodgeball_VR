using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class VRModeObjectScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (DetectVRHeadset.VRMode)
        {
            // Vector3 scale = transform.scale;
            float mult = 0.8f;
            transform.localScale = transform.localScale * mult;
            Debug.Log("Object scale: ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
