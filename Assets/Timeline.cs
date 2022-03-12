using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public GameObject body, startButton, germCloud;
    public Vector3 startButtonPosition = new Vector3(0.4f, 0.9f, 0f);
    public Vector3 germCloudPosition = new Vector3(0f, 0f, -2f);
    public GameObject sliderGB;
    public Slider slider;
    
  


    private void OnEnable()
    {
        StartScreen();
    }
    // Start is called before the first frame update
    void Start()
    {
        //sliderGB = GameObject.FindGameObjectWithTag("Slider");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScreen()
    {
        var prefabLocation = body.transform.localPosition + startButtonPosition;
        Instantiate(startButton, prefabLocation, Quaternion.identity);
    } 
    public void PreCovid()
    {
        Debug.Log("preCovid");
        sliderGB.SetActive(true);
        Destroy(GameObject.Find("StartUI(Clone)"));
        GameObject.FindGameObjectWithTag("Logo").SetActive(false);
        
    }
    public void FirstExposure()
    {
        Debug.Log("First Exposure");
        // instantiate Covid particles

        var myprefabLocation = body.transform.position + germCloudPosition;
        Instantiate(germCloud, myprefabLocation, Quaternion.identity);
    }
    public void TravelToLungs()
    {
        Debug.Log("Travel to lungs");


    }
    public void CovidSetsIn()
    {
        Debug.Log("Covid Sets In");
    }
    public void CovidWorsens()
    {
        Debug.Log("Covid Worsens");
    }
    public void LungFailure()
    {
        Debug.Log("Lung Failure");
    }
    public void BenefitOfVaccination()
    {
        Debug.Log("Benefit Of Vaccination");
    }
    public void EndScreen()
    {
        Debug.Log("End of Screen");
    }

    public void TimelineController()
    {
        Debug.Log("Value changed to " + slider.value);
        
        switch(slider.value)
        {
            case 1:
                PreCovid();
                break;

            case 2:
                FirstExposure();
                break;
            case 3:
                TravelToLungs();
                break;

            case 4:
                CovidSetsIn();
                break;
            case 5:
                CovidWorsens();
                break;

            case 6:
                LungFailure();
                break;
            case 7:
                BenefitOfVaccination();
                break;

        }

    }


}
