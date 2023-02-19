using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime;

    float currentTime;
    bool timeStarted = false;
    public bool gameStartPressed = false;
    public GameObject beginCanv;
    public GameObject timerCanv;
    public GameObject endCanv;
    public GameObject clock;
    public Objects objnum;


    [SerializeField] TMP_Text timeText;


    void Start()
    {
        currentTime = startTime;
        //timeText.text = currentTime.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStartPressed)
        {
            timeStarted = true;
        }

        if (timeStarted)
        {
            beginCanv.SetActive(false);
            timerCanv.SetActive(true);
            clock.SetActive(true);

            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                Debug.Log("time's up");
                timeStarted = false;
                currentTime = 0;
                endCanv.SetActive(true);
                if(objnum.winning == true)
                {
                    timeText.text = "You did it! Nice job. Keep up the mess!";
                }
                else
                {
                    timeText.text = "Eh… still pretty clean. Could be messier…";
                }
                
            }
        }

       // timeText.text = currentTime.ToString("f1");

    }
}
