using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartExperience : MonoBehaviour
{
    
    public GameObject body;
    public Timeline timeline;
    private int i = 0;
    private float  growFactor =0 ;
    public string buttonOption;

    public GameObject answerTextBody;

    // Start is called before the first frame update
    void Start()
    {
        //TopLeftUI = GameObject.FindGameObjectsWithTag("TopLeftUI")[0];
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        answerTextBody = GameObject.Find("EditorLorem");

    }

    // Update is called once per frame
    void Update()
    {
        body = GameObject.Find("Body");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, body.transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        i++;
        growFactor = growFactor + 0.00001f ;

        Debug.Log("Grow factor" + growFactor);
        Debug.Log("Triggered");
        Debug.Log(i);
        this.gameObject.transform.localScale = this.gameObject.transform.localScale  + new Vector3(growFactor ,growFactor ,growFactor);

        if (i==120)
        {
            if (this.gameObject.name == "Start")
            {
                timeline.PreCovid();
            }
            else
            {
                this.gameObject.SetActive(false);
                switch(this.gameObject.name)
                {
                    case "right 0":
                        HowLong();
                        break;
                    case "right 1":
                        VaccineContents();
                        break;
                    case "left 0":
                        AlreadyContracted();
                        break;
                    case "left 1":
                        break;
                    
                }
            }
        }
      //  timeline.PreCovid();



    }

    private void AlreadyContracted()
    {
        throw new NotImplementedException();
    }

    private void VaccineContents()
    {
        throw new NotImplementedException();
    }

    private void HowLong()
    {
        throw new NotImplementedException();
    }

    IEnumerator TriggerButtonAction()
    {
        yield return new WaitForSeconds(5);
    }
}
