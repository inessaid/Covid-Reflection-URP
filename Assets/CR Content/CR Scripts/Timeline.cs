using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timeline : MonoBehaviour
{
    public GameObject body, sampleButton, germCloud, covidParticle, lungs;
    public Vector3 startButtonPosition = new Vector3(0.4f, 0.9f, 0f);
    public Vector3 germCloudPosition = new Vector3(0f, 0f, -2f);
    public GameObject sliderGB, logo;
    public Slider slider;
    [SerializeField] private Renderer lungRenderer;
    public Material lungWithCovidMat, lungWithPneumonia;
    public TMP_Text state;
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
        var instantiatedButton =  Instantiate(sampleButton, prefabLocation, Quaternion.identity);
        instantiatedButton.gameObject.name = "Start";

        state.gameObject.SetActive(true);
    } 
    public void PreCovid()
    {
        Debug.Log("preCovid");
        state.SetText("Pre Covid");
        //disable logo
        logo.SetActive(false);
        // enable logo
        sliderGB.SetActive(true);
        GameObject.Find("Start").SetActive(false);
        GameObject.FindGameObjectWithTag("Logo").SetActive(false);
        
    }
    public void FirstExposure()
    {
        Debug.Log("First Exposure");
        state.SetText("First Exposure");

        // instantiate Covid particles
        var myprefabLocation = body.transform.position + germCloudPosition;
        Instantiate(germCloud, myprefabLocation, Quaternion.identity);
    }
    public void TravelToLungs()
    {
        Debug.Log("Travel to lungs");
        state.SetText("Travel To Lungs");
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
        state.SetText("Covid Sets In");
        covidParticle.SetActive(false);
        lungRenderer.material.SetFloat("_alpha", 1f);
        lungRenderer.material = lungWithCovidMat;
    }
    public void CovidWorsens()
    {
        Debug.Log("Covid Worsens");
        state.SetText("Covid Worsens");
        lungRenderer.material = lungWithPneumonia;
    }
    public void LungFailure()
    {
        state.SetText("Lung Failure");
        Debug.Log("Lung Failure");
    }
    public void BenefitOfVaccination()
    {
        state.SetText("Benefit Of Vaccination");
        Debug.Log("Benefit Of Vaccination");
    }
    public void FreeForm()
    {
        state.SetText("Free Form");
        Debug.Log("Free Form");
        for (int i = 0; i < 4; i++)
        {
            // right Button
            var prefabLocationRight = body.transform.localPosition + new Vector3(0.4f, i-1, 0f);
            var instantiatedButtonRight = Instantiate(sampleButton, prefabLocationRight, Quaternion.identity);
            instantiatedButtonRight.gameObject.name = "right" + " " + i.ToString();

            // Left Button

            var prefabLocationLeft = body.transform.localPosition + new Vector3(-0.4f, i-1, 0f);
            var instantiatedButtonLeft = Instantiate(sampleButton, prefabLocationLeft, Quaternion.identity);
            instantiatedButtonLeft.gameObject.name = "Left" + " " + i.ToString();


        }
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
            case 8:
                FreeForm();
                break;

        }

    }




}
