using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerUI : MonoBehaviour
{
    public GameObject TopLeftUI;
    
    // Start is called before the first frame update
    void Start()
    {
        //TopLeftUI = GameObject.FindGameObjectsWithTag("TopLeftUI")[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        //TopLeftUI.SetActive(true);
        GameObject go = Instantiate(TopLeftUI, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        

        // go.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left , 0

        
    }


}
