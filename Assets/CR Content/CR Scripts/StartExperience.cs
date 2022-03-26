using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExperience : MonoBehaviour
{
    
    public GameObject body;
    public Timeline timeline;

    // Start is called before the first frame update
    void Start()
    {
        //TopLeftUI = GameObject.FindGameObjectsWithTag("TopLeftUI")[0];
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();

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



        timeline.PreCovid();



    }
}
