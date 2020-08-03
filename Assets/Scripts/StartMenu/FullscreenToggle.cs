using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    public void Fullscreen(bool is_fullscreen)
    {
        Screen.fullScreen = is_fullscreen;
        Debug.Log("Fullscreen is " + is_fullscreen);
    }
}
