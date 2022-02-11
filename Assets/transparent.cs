using System.Collections;
using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class transparent : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject mycamera, body;
    void Start()
    {
        // gb = MarsRuntimeUtils.GetActiveCamera(true).GetComponent<ARCameraManager>().gameObject;

        Invoke("wakeup", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //mymaterial = MarsRuntimeUtils.GetActiveCamera(true).GetComponent<ARCameraManager>().cameraMaterial;
        //mymaterial.color = Color.clear;
    }


    void wakeup()
    {
        mycamera.active = true;
        gameObject.transform.position = body.transform.position + new Vector3(0, 2, 0);
        
    }
}
