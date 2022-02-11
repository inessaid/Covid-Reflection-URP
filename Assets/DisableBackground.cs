using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DisableBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ARCameraBackground>().enabled = false;
    }
}
