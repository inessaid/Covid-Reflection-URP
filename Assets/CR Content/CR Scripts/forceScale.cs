using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceScale : MonoBehaviour
{
    public GameObject heart;

    // Update is called once per frame
    void Update()
    {
        heart.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }
}
