using System.Collections;
using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class transparent : MonoBehaviour
{
    // Start is called before the first frame update

    public float distance;
    public GameObject mycamera, body;
    public GameObject UIPrefab;
    private Vector3 prefabLocation;
    public float x, y, z;
    void Start()
    {
        // gb = MarsRuntimeUtils.GetActiveCamera(true).GetComponent<ARCameraManager>().gameObject;

        Invoke("wakeup", 3f);
        Invoke("ShowUI", 5f);
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
        mycamera.transform.position = body.transform.position + new Vector3(0, 0, distance);
        
    }

    void ShowUI()
    {
        prefabLocation = body.transform.localPosition + new Vector3(x,y,z); 
        Instantiate(UIPrefab, prefabLocation, Quaternion.identity);
    }
}
