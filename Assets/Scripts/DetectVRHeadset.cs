using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVRHeadset : MonoBehaviour
{
    [SerializeField] private GameObject VRPlayerController;
    [SerializeField] private GameObject NonVRPlayerController;
    // Awake() runs before Start()
    void Awake()
    {
        if (UnityEngine.XR.XRDevice.isPresent) {
            Debug.LogWarning("VR Headset Found");
            Instantiate(VRPlayerController, new Vector3(0,1,0), Quaternion.identity);
        } else {
            Debug.LogWarning("VR Headset Not Found");
            Instantiate(NonVRPlayerController, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
