using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public GameObject body, startButton, germCloud, covidParticle, lungs;
    public Vector3 startButtonPosition = new Vector3(0.4f, 0.9f, 0f);
    public Vector3 germCloudPosition = new Vector3(0f, 0f, -2f);
    public GameObject sliderGB, logo;
    public Slider slider;
    [SerializeField] private Renderer lungRenderer;
    public Material lungWithCovidMat;
   // public Material lungMaterial;




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
        //disable logo
        logo.SetActive(false);
        // enable logo
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

        // set oof  particle germs 
        GameObject.Find("Germ Cloud(Clone)").SetActive(false);

        //make lungs transparent   
        lungRenderer.material.SetFloat("_alpha", 0.3f);

        // Covid particle goes into lungs
        covidParticle.SetActive(true);



    }
    public void CovidSetsIn()
    {
        Debug.Log("Covid Sets In");
        lungRenderer.material.SetFloat("_alpha", 1f);
        lungRenderer.material = lungWithCovidMat;
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
