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
    public GameObject sliderGB, logo, timer;
    public Slider slider;
    [SerializeField] private Renderer lungRenderer, humanRenderer;
   // public Material lungWithCovidMat, lungWithPneumonia;
    public Text state;
    private float counter=0;
    private bool counterTrigger;
    public float speed;
    private bool particleTrigger, pneumoniaTrigger;
    public AudioSource[] audios;
    private Color originalColor;
  
   // public Material lungMaterial;




    private void OnEnable()
    {
        StartScreen();
      
    }
    // Start is called before the first frame update
    void Start()
    {
        //sliderGB = GameObject.FindGameObjectWithTag("Slider");
        counter = 0;
       
        counterTrigger = false;
        particleTrigger = false;
        pneumoniaTrigger = false;
        originalColor = humanRenderer.material.GetColor("_edge_color");
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(counter);

        //if (counterTrigger && particleTrigger)
        //{
        //    counter=Mathf.Lerp(0, 1, Time.time * speed);
             
        //    lungRenderer.material.SetFloat("_particle_trigger", counter);

        //    // lungRenderer.material.SetFloat("_pneumonia_trigger", counter);


        //}

        //if (counterTrigger && pneumoniaTrigger)
        //{
        //    counter = Mathf.Lerp(0, 1, Time.time * speed);

        //    lungRenderer.material.SetFloat("_pneumonia_trigger", counter);


        //}

        //if (counter > 0.98)
        //{
        //    counterTrigger = false;
        //    pneumoniaTrigger = false;
        //    particleTrigger = false;
        //    counter = 0;


        //}

        
    }

    public void StartScreen()
    {
        // humanRenderer.material.SetColor("_edge_color", originalColor);
        
        var prefabLocation = body.transform.localPosition + startButtonPosition;
        var instantiatedButton =  Instantiate(sampleButton, prefabLocation, Quaternion.identity);
        instantiatedButton.gameObject.name = "Start";

        state.gameObject.SetActive(true);
        sliderGB.SetActive(false);
        timer.SetActive(false);
       
        lungRenderer.material.SetFloat("_particle_trigger", 0f);
        lungRenderer.material.SetFloat("_base_trigger", 0f);
        lungRenderer.material.SetFloat("_pneumonia_trigger", 0f);
    } 
    public void PreCovid()
    {
       // Debug.Log("preCovid");
       // state.SetText("Pre Covid");
        state.text = "Pre Covid";
        audios[0].Play();
        timer.SetActive(true);
        slider.value = 1;
        lungRenderer.material.SetFloat("_particle_trigger", 0f);
        lungRenderer.material.SetFloat("_base_trigger", 1f);
        lungRenderer.material.SetFloat("_pneumonia_trigger", 0f);
        //disable logo
        logo.SetActive(false);
        // enable logo
        sliderGB.SetActive(true);
        GameObject.Find("Start").SetActive(false);
        //GameObject.FindGameObjectWithTag("Logo").SetActive(false);
        
    }
    public void FirstExposure()
    {
        //Debug.Log("First Exposure");
        // state.SetText("First Exposure");
        state.text = "First Exposure";
        audios[1].Play();

        // instantiate Covid particles
        var myprefabLocation = body.transform.position + germCloudPosition;
        Instantiate(germCloud, myprefabLocation, Quaternion.identity);
    }
    public void TravelToLungs()
    {
        // Debug.Log("Travel to lungs");
        // state.SetText("Travel To Lungs");
        state.text = "Travel To Lungs";

        audios[2].Play();
        // set oof  particle germs 
        GameObject.Find("Germ Cloud(Clone)").SetActive(false);

        //make lungs transparent   
        lungRenderer.material.SetFloat("_alpha", 0.3f);

        // Covid particle goes into lungs
        covidParticle.SetActive(true);



    }
    public void CovidSetsIn()
    {
        //Debug.Log("Covid Sets In");
        //state.SetText("Covid Sets In");
        state.text = "Covid Sets In";
        audios[3].Play();
        humanRenderer.materials[0].SetColor("_edge_color", Color.yellow);
        humanRenderer.materials[1].SetColor("_edge_color", Color.yellow);
        humanRenderer.materials[2].SetColor("_edge_color", Color.yellow);
        covidParticle.SetActive(false);
        lungRenderer.material.SetFloat("_alpha", 1f);
        // lungRenderer.material = lungWithCovidMat;
        counterTrigger = true;
        particleTrigger = true;
        lungRenderer.material.SetFloat("_particle_trigger", 1f);
        lungRenderer.material.SetFloat("_base_trigger", 0f);
        lungRenderer.material.SetFloat("_pneumonia_trigger", 0f);
    }
    public void CovidWorsens()
    {
        // Debug.Log("Covid Worsens");
        //state.SetText("Covid Worsens");
        state.text = "Covid Worsens";
        audios[4].Play();
        // lungRenderer.material = lungWithPneumonia;
        //counterTrigger = true;
        lungRenderer.material.SetFloat("_particle_trigger", 0f);
        lungRenderer.material.SetFloat("_base_trigger", 0f);
        lungRenderer.material.SetFloat("_pneumonia_trigger", 1f);
    }
    public void LungFailure()
    {
        //state.SetText("Lung Failure");
        state.text = "Lung Failure";
        humanRenderer.materials[0].SetColor("_edge_color", Color.red);
        humanRenderer.materials[1].SetColor("_edge_color", Color.red);
        humanRenderer.materials[2].SetColor("_edge_color", Color.red);
        audios[5].Play();
        // Debug.Log("Lung Failure");
    }
    public void BenefitOfVaccination()
    {
        //state.SetText("Benefit Of Vaccination");
        state.text = "Benefit Of Vaccination";
        humanRenderer.materials[0].SetColor("_edge_color", originalColor);
        humanRenderer.materials[1].SetColor("_edge_color", originalColor);
        humanRenderer.materials[2].SetColor("_edge_color", originalColor);
        audios[6].Play();
        // Debug.Log("Benefit Of Vaccination");
    }
    public void FreeForm()
    {
        //state.SetText("Free Form");
        state.text = "Free Form";
        // Debug.Log("Free Form");
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
       // Debug.Log("End of Screen");
    }

    public void TimelineController()
    {
      //  Debug.Log("Value changed to " + slider.value);
        
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
