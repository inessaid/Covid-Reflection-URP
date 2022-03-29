using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCoroutine : MonoBehaviour
{
    public float waitTime;
    private void OnEnable()
    {
        StartCoroutine(Fade());
    }


    IEnumerator Fade()
    {
        // precovid
        this.GetComponent<Slider>().value = 1;
        yield return new WaitForSeconds(waitTime);
        //
        this.GetComponent<Slider>().value = 2;
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<Slider>().value = 3;
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<Slider>().value = 4;
        yield return new WaitForSeconds(waitTime +waitTime);
        this.GetComponent<Slider>().value = 5;
        yield return new WaitForSeconds(waitTime + waitTime);
        this.GetComponent<Slider>().value = 6;
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<Slider>().value = 7;
        yield return new WaitForSeconds(waitTime);
        this.GetComponent<Slider>().value = 8;

    }

}
