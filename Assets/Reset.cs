using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reset : MonoBehaviour
{
    public Timer timerScript;
    public GameObject timeline;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timerScript.timeRemaining;
        if (timer < 1)
        {
            timerScript.timeRemaining = 130;
            timeline.SetActive(false);
            timeline.SetActive(true);
        }
    }
}
