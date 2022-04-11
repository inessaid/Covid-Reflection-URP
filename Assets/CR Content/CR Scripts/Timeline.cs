using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timeline : MonoBehaviour
{
    public GameObject body, sampleButton, germCloud, covidParticle, lungs, forceField, respirator;
    public Vector3 startButtonPosition = new Vector3(0.4f, 0.9f, 0f);
    public Vector3 germCloudPosition = new Vector3(0f, 0f, -2f);
    public GameObject sliderGB, logo, timer;
    public Slider slider;
    [SerializeField] private Renderer lungRenderer, humanRenderer, shieldRenderer;
    // public Material lungWithCovidMat, lungWithPneumonia;
    public Text state;
    private float counter = 0;
    private bool counterTrigger, shieldTrigger, closeShieldTrigger, AlphaTrigger, removeAlphaTrigger, removeParticleTrigger, blueToYelowTrigger, yellowToRedTrigger, redToBlueTrigger;
    public float speed, changeSpeed;
    private bool particleTrigger, pneumoniaTrigger;
    public AudioSource[] audios;
    private Color originalColor;
    private float tempShieldVal, closeShieldVal, tempAlphaValue, tempParticleValue, tempPneuValue;
    private Color red, yellow, blue;
    public float intensity = 0.2f;
    private float t = 0, tr = 0 , tb=0;
    public float duration;


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

        InitializeTriggers();
        InitializeTempValues();
        originalColor = humanRenderer.material.GetColor("_edge_color");

        


        red = new Color(255 * intensity, 0 * intensity, 0 * intensity);




    }

   



    // Update is called once per frame
    void Update()
    {
        BlueToYellow();
        YellowToRed();
        RedToBlue();


        if (pneumoniaTrigger)
        {

            if (tempPneuValue < 1f)
            {
                tempPneuValue += changeSpeed * Time.deltaTime;
                lungRenderer.material.SetFloat("_pneumonia_trigger", tempPneuValue);
            }

        }

        // remove particle
        if (removeParticleTrigger)
        {
            if (tempParticleValue > 0f)
            {
                tempParticleValue -= changeSpeed * Time.deltaTime;
                lungRenderer.material.SetFloat("_particle_trigger", tempParticleValue);
            }
            else
            {
                removeParticleTrigger = false;
            }
        }

        // add particle
        if (particleTrigger)
        {
            if (tempParticleValue < 1f)
            {
                tempParticleValue += changeSpeed * Time.deltaTime;
                lungRenderer.material.SetFloat("_particle_trigger", tempParticleValue);
            }
            else
            {
                particleTrigger = false;
            }
        }

        // remove alpha
        if (removeAlphaTrigger)
        {
            if (tempAlphaValue < 1f)
            {
                tempAlphaValue += changeSpeed * Time.deltaTime;
                lungRenderer.material.SetFloat("_alpha", tempAlphaValue);
            }
            else
            {
                AlphaTrigger = false;
            }
        }


        // add alpha
        if (AlphaTrigger)
        {
            if (tempAlphaValue > 0.3f)
            {
                tempAlphaValue -= changeSpeed * Time.deltaTime;
                lungRenderer.material.SetFloat("_alpha", tempAlphaValue);
            }
            else
            {
                AlphaTrigger = false;
            }
        }


        if (shieldTrigger)
        {
            //float temp = Mathf.Lerp(-0.2f, 1.2f, Time.time * speed);
            //Debug.Log("Temp " + temp);
            //shieldRenderer.material.SetFloat("_disolve", temp);
            if (tempShieldVal > -0.2f)
            {

                tempShieldVal -= speed * Time.deltaTime;
                //Debug.Log("Temp " + tempShieldVal);
                shieldRenderer.material.SetFloat("_disolve", tempShieldVal);
            }
            else
            {
                shieldTrigger = false;
            }

        }

        if (closeShieldTrigger)
        {
            //float temp = Mathf.Lerp(-0.2f, 1.2f, Time.time * speed);
            //Debug.Log("Temp " + temp);
            //shieldRenderer.material.SetFloat("_disolve", temp);
            if (closeShieldVal < 2.2f)
            {
                closeShieldVal += speed * Time.deltaTime;
               // Debug.Log("Temp " + closeShieldVal);
                shieldRenderer.material.SetFloat("_disolve", closeShieldVal);
            }

        }


    }



    public void StartScreen()
    {
        TurnOffUIOrbs();
        InitializeTriggers();
        InitializeTempValues();
        // humanRenderer.material.SetColor("_edge_color", originalColor);
        respirator.SetActive(false);

        var prefabLocation = body.transform.localPosition + startButtonPosition;
        var instantiatedButton = Instantiate(sampleButton, prefabLocation, Quaternion.identity);
        instantiatedButton.gameObject.name = "Start";

        state.gameObject.SetActive(false);
        sliderGB.SetActive(false);
        timer.SetActive(false);

        lungRenderer.material.SetFloat("_particle_trigger", 0f);
        lungRenderer.material.SetFloat("_base_trigger", 1f);
        lungRenderer.material.SetFloat("_pneumonia_trigger", 0f);
    }
    public void PreCovid()
    {

        // Debug.Log("preCovid");
        // state.SetText("Pre Covid");
        state.gameObject.SetActive(true);
        respirator.SetActive(false);
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
        Destroy(GameObject.Find("Start"));
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
        // lungRenderer.material.SetFloat("_alpha", 0.3f);
        AlphaTrigger = true;

        // Covid particle goes into lungs
        covidParticle.SetActive(true);



    }
    public void CovidSetsIn()
    {
        //Debug.Log("Covid Sets In");
        //state.SetText("Covid Sets In");
        state.text = "Covid Sets In";
        audios[3].Play();
        blueToYelowTrigger = true;
        removeAlphaTrigger = true;
        covidParticle.SetActive(false);
        counterTrigger = true;
        particleTrigger = true;
        // lungRenderer.material.SetFloat("_particle_trigger", 1f);
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
        //lungRenderer.material.SetFloat("_particle_trigger", 0f);
        removeParticleTrigger = true;
        lungRenderer.material.SetFloat("_base_trigger", 0f);
        pneumoniaTrigger = true;
        //lungRenderer.material.SetFloat("_pneumonia_trigger", 1f);
    }
    public void LungFailure()
    {
        //state.SetText("Lung Failure");
        state.text = "Lung Failure";
        respirator.SetActive(true);

        yellowToRedTrigger = true;
        //humanRenderer.materials[0].SetColor("_edge_color", red);
        //humanRenderer.materials[1].SetColor("_edge_color", red);
        //humanRenderer.materials[2].SetColor("_edge_color", red);
        audios[5].Play();
        // Debug.Log("Lung Failure");
    }
    public void BenefitOfVaccination()
    {
        respirator.SetActive(false);
        //state.SetText("Benefit Of Vaccination");
        state.text = "Benefit Of Vaccination";
        forceField.SetActive(true);

        shieldTrigger = true;


        redToBlueTrigger = true;
        audios[6].Play();

        lungRenderer.material.SetFloat("_base_trigger", 1f);
        lungRenderer.material.SetFloat("_pneumonia_trigger", 0f);
        // Debug.Log("Benefit Of Vaccination");
    }
    public void FreeForm()
    {
        //forceField.SetActive(false);
        closeShieldTrigger = true;
        //state.SetText("Free Form");
        state.text = "Free Form";
        // Debug.Log("Free Form");
        for (int i = 0; i < 2; i++)
        {
            // right Button
            var prefabLocationRight = body.transform.localPosition + new Vector3(0.5f, i - 0.1f, 0f);
            var instantiatedButtonRight = Instantiate(sampleButton, prefabLocationRight, Quaternion.identity);
            instantiatedButtonRight.gameObject.name = "right" + " " + i.ToString();


            // Left Button

            var prefabLocationLeft = body.transform.localPosition + new Vector3(-0.5f, i - 0.1f, 0f);
            var instantiatedButtonLeft = Instantiate(sampleButton, prefabLocationLeft, Quaternion.identity);
            instantiatedButtonLeft.gameObject.name = "left" + " " + i.ToString();


        }
    }
    public void EndScreen()
    {
        // Debug.Log("End of Screen");
    }

    public void TimelineController()
    {
        //  Debug.Log("Value changed to " + slider.value);

        switch (slider.value)
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

    public void TurnOffUIOrbs()
    {
        if (GameObject.Find("right 0"))
        {
            //GameObject.Find("right 0").SetActive(false);
            Destroy(GameObject.Find("right 0"));
        }

        if (GameObject.Find("right 1"))
        {
            //GameObject.Find("right 1").SetActive(false);
            Destroy(GameObject.Find("right 1"));
        }

        if (GameObject.Find("left 0"))
        {
            //GameObject.Find("left 0").SetActive(false);
            Destroy(GameObject.Find("left 0"));
        }

        if (GameObject.Find("left 1"))
        {
            //GameObject.Find("left 1").SetActive(false);
            Destroy(GameObject.Find("left 1"));
        }

    }

    public void BlueToYellow()
    {
        if (blueToYelowTrigger)
        {
            if (t < 1)
            { // while t below the end limit...
              // increment it at the desired rate every update:
                t += Time.deltaTime / duration;
            }
            else
            {
                blueToYelowTrigger = false;


            }
            Color lerpedColor = Color.white;
            lerpedColor = Color.Lerp(originalColor, Color.yellow, t);

            humanRenderer.materials[0].SetColor("_edge_color", lerpedColor);
            humanRenderer.materials[1].SetColor("_edge_color", lerpedColor);
            humanRenderer.materials[2].SetColor("_edge_color", lerpedColor);

        }
    }


    public void RedToBlue()
    {
        if (redToBlueTrigger)
        {
            if (tb < 1)
            { // while t below the end limit...
              // increment it at the desired rate every update:
                tb += Time.deltaTime / duration;
            }
            else
            {
                blueToYelowTrigger = false;


            }
            Color lerpedColor = Color.white;
            lerpedColor = Color.Lerp( Color.red ,originalColor, tb);

            humanRenderer.materials[0].SetColor("_edge_color", lerpedColor);
            humanRenderer.materials[1].SetColor("_edge_color", lerpedColor);
            humanRenderer.materials[2].SetColor("_edge_color", lerpedColor);

        }
    }
    private void YellowToRed()
    {
        if (yellowToRedTrigger)
        {
            //if (tr < 1)
            //{ // while t below the end limit...
            //  // increment it at the desired rate every update:
            //    tr += Time.deltaTime / duration;
            //}
            //else
            //{
            //    yellowToRedTrigger = false;


            //}
            Color lerpedColor = Color.white;
            // lerpedColor = Color.Lerp(Color.yellow, Color.red, tr);
            lerpedColor = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time, 1));

            humanRenderer.materials[0].SetColor("_edge_color", lerpedColor);
            humanRenderer.materials[1].SetColor("_edge_color", lerpedColor);
            humanRenderer.materials[2].SetColor("_edge_color", lerpedColor);

        }
    }
    private void FlashingRed()
    {
        throw new NotImplementedException();
    }

    private void InitializeTriggers()
    {
        redToBlueTrigger = false;
        yellowToRedTrigger = false;
        blueToYelowTrigger = false;
        removeParticleTrigger = false;
        removeAlphaTrigger = false;
        counterTrigger = false;
        particleTrigger = false;
        pneumoniaTrigger = false;
        shieldTrigger = false;

    }
    private void InitializeTempValues()
    {
        t = 0;
        tr = 0;
        tb = 0;
        tempShieldVal = 0.9f;
        closeShieldVal = -0.2f;
        tempAlphaValue = 1;
        tempParticleValue = 0;
        tempPneuValue = 0;
    }




}
