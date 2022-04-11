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
    public AudioSource buttonPop;
    //public GameObject audioGB;
    //public AudioSource howLong;

    public GameObject answerTextBody;

    // Start is called before the first frame update
    void Start()
    {
        
       // UIel.transform.parent = GameObject.Find("SliderCanvas").transform;

        //TopLeftUI = GameObject.FindGameObjectsWithTag("TopLeftUI")[0];
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        answerTextBody = GameObject.Find("EditorLorem");
        //audioGB = GameObject.Find("Audios");
        //howLong = audioGB.transform.Find("How Long").gameObject.GetComponent<AudioSource>();
        buttonPop = GameObject.Find("ButtonPop").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        body = GameObject.Find("Body");
      //  this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, body.transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        buttonPop.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        i++;
        growFactor = growFactor + 0.00001f ;
        
       // Debug.Log("Grow factor" + growFactor);
       // Debug.Log("Triggered");
       // Debug.Log(i);

        this.gameObject.transform.localScale = this.gameObject.transform.localScale  + new Vector3(growFactor ,growFactor ,growFactor);

        if (i==120)
        {
            if (this.gameObject.name == "Start")
            {
                timeline.PreCovid();
            }
            else
            {
                
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
                Destroy(this.gameObject);
            }
        }
      //  timeline.PreCovid();



    }


    private void Covid19Safe()
    {
        GameObject covid19Safe = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        covid19Safe.gameObject.name = "Covid19Safes";
        covid19Safe.transform.GetChild(0).GetComponent<Text>().text = "Are Covid-19 vaccinations safe?";
        covid19Safe.transform.GetChild(1).GetComponent<Text>().text = "COVID-19 Vaccines are safe. Rigorous clinical testing, FDA review, and extensive tracking were conducted on the vaccines to ensure they are safe and effective. ";
        GameObject.Find("Covid 19 Safe").GetComponent<AudioSource>().Play();
        GameObject.Find("How Long").GetComponent<AudioSource>().Stop();
        Debug.Log("This shoudl say how long  "+GameObject.Find("How Long").GetComponent<AudioSource>());
        GameObject.Find("Vaccine Contents").GetComponent<AudioSource>().Stop();
        GameObject.Find("Already Contracted").GetComponent<AudioSource>().Stop();
 
        Destroy(covid19Safe, 10);
    }

    private void AlreadyContracted()
    {
        //Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        //UIprefab.transform.GetChild(0).GetComponent<Text>().text = "Already Contracted";
        GameObject alreadyContracted = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        alreadyContracted.gameObject.name = "Already Contracteds";
        alreadyContracted.transform.GetChild(0).GetComponent<Text>().text = "Already Had Covid-19?";
        alreadyContracted.transform.GetChild(1).GetComponent<Text>().text = "Ever after recovering from COVID-19, a vaccination can help reduce the risk of contracting COVID-19 again, and reduce the severity if you do get sick.";
        GameObject.Find("Already Contracted").GetComponent<AudioSource>().Play();
        GameObject.Find("How Long").GetComponent<AudioSource>().Stop();
        GameObject.Find("Vaccine Contents").GetComponent<AudioSource>().Stop();
        GameObject.Find("Covid 19 Safe").GetComponent<AudioSource>().Stop();
        Destroy(alreadyContracted, 10);
    }

    private void VaccineContents()
    {
        //Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        //UIprefab.transform.GetChild(0).GetComponent<Text>().text = "Vaccine Contents";

        GameObject vaccineContents = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        vaccineContents.gameObject.name = "Vaccine Contentss";
        vaccineContents.transform.GetChild(0).GetComponent<Text>().text = "What are contained in vaccines?";
        vaccineContents.transform.GetChild(1).GetComponent<Text>().text = "While vaccine contents vary by manufacturer, there are no eggs, gelatine, preservatives, metals, or microelectronics contained in any vaccine. No vaccine contains any live virus.";

        GameObject.Find("Vaccine Contents").GetComponent<AudioSource>().Play();
        GameObject.Find("How Long").GetComponent<AudioSource>().Stop();
        GameObject.Find("Already Contracted").GetComponent<AudioSource>().Stop();
        GameObject.Find("Covid 19 Safe").GetComponent<AudioSource>().Stop();

        Destroy(vaccineContents, 10);

    }

    private void HowLong()
    {
        //Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        //UIprefab.transform.GetChild(0).GetComponent<Text>().text = "How Long";
        //Debug.Log(UIprefab.transform.GetChild(0).name);
        //Debug.Log(UIprefab.transform.GetChild(0).GetComponent<Text>().text);

        GameObject howLong = Instantiate(UIprefab, GameObject.Find("SliderCanvas").transform);
        howLong.gameObject.name = "How Longs";
        howLong.transform.GetChild(0).GetComponent<Text>().text = "How long does protection last?";
        howLong.transform.GetChild(1).GetComponent<Text>().text = "The CDC recommends that a booster shot is obtained at least 5 months after receiving either a Pfizer or Moderna vaccination. ";
        //audios[6].Play();
        GameObject.Find("How Long").GetComponent<AudioSource>().Play();
        GameObject.Find("Vaccine Contents").GetComponent<AudioSource>().Stop();
        GameObject.Find("Already Contracted").GetComponent<AudioSource>().Stop();
        GameObject.Find("Covid 19 Safe").GetComponent<AudioSource>().Stop();
        Destroy(howLong, 10);
        
    }

    IEnumerator TriggerButtonAction()
    {
        yield return new WaitForSeconds(5);

    }
}
