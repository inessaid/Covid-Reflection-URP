using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerUI : MonoBehaviour
{
    public GameObject TopLeftUI;
    public GameObject body;
    
    // Start is called before the first frame update
    void Start()
    {
        //TopLeftUI = GameObject.FindGameObjectsWithTag("TopLeftUI")[0];

    }

    // Update is called once per frame
    void Update()
    {
        body = GameObject.Find("Body");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, body.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        
        GameObject go = Instantiate(TopLeftUI, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        

        

        
    }


}
