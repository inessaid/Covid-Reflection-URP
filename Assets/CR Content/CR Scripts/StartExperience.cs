using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartExperience : MonoBehaviour
{
    
    public GameObject body, UIprefab;
    public Timeline timeline;
    private int i = 0;
    private float  growFactor =0 ;
    public string buttonOption;

    public GameObject answerTextBody;

    // Start is called before the first frame update
    void Start()
    {
        
       // UIel.transform.parent = GameObject.Find("SliderCanvas").transform;

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
                        Covid19Safe();
                        break;
                    
                }
            }
        }
      //  timeline.PreCovid();



    }


    private void Covid19Safe()
    {
        GameObject covid19Safe = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        covid19Safe.gameObject.name = "Covid19Safe";
        covid19Safe.transform.GetChild(0).GetComponent<Text>().text = "Are Covid-19 vaccinations safe?";
        covid19Safe.transform.GetChild(1).GetComponent<Text>().text = "COVID-19 Vaccines are safe. Rigorous clinical testing, FDA review, and extensive tracking were conducted on the vaccines to ensure they are safe and effective. ";
        Destroy(covid19Safe, 5);
    }

    private void AlreadyContracted()
    {
        //Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        //UIprefab.transform.GetChild(0).GetComponent<Text>().text = "Already Contracted";
        GameObject alreadyContracted = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        alreadyContracted.gameObject.name = "Already Contracted";
        alreadyContracted.transform.GetChild(0).GetComponent<Text>().text = "Already Had Covid-19?";
        alreadyContracted.transform.GetChild(1).GetComponent<Text>().text = "Ever after recovering from COVID-19, a vaccination can help reduce the risk of contracting COVID-19 again, and reduce the severity if you do get sick.";
        Destroy(alreadyContracted, 5);
    }

    private void VaccineContents()
    {
        //Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        //UIprefab.transform.GetChild(0).GetComponent<Text>().text = "Vaccine Contents";

        GameObject vaccineContents = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        vaccineContents.gameObject.name = "Vaccine Contents";
        vaccineContents.transform.GetChild(0).GetComponent<Text>().text = "What are contained in vaccines?";
        vaccineContents.transform.GetChild(1).GetComponent<Text>().text = "While vaccine contents vary by manufacturer, there are no eggs, gelatine, preservatives, metals, or microelectronics contained in any vaccine. No vaccine contains any live virus.";
        Destroy(vaccineContents, 5);

    }

    private void HowLong()
    {
        //Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        //UIprefab.transform.GetChild(0).GetComponent<Text>().text = "How Long";
        //Debug.Log(UIprefab.transform.GetChild(0).name);
        //Debug.Log(UIprefab.transform.GetChild(0).GetComponent<Text>().text);

        GameObject howLong = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        howLong.gameObject.name = "How Long";
        howLong.transform.GetChild(0).GetComponent<Text>().text = "How long does protection last?";
        howLong.transform.GetChild(1).GetComponent<Text>().text = "The CDC recommends that a booster shot is obtained at least 5 months after receiving either a Pfizer or Moderna vaccination. ";
        Destroy(howLong, 5);
        
    }

    IEnumerator TriggerButtonAction()
    {
        yield return new WaitForSeconds(5);

    }
}
