using UnityEngine;
using TMPro;
using UnityEngine.UI;

//this script is the stopwatch to measure how long it takes to beat the obstacle course
public class Timer : MonoBehaviour
{
    public bool stopwatchActive;
    public static float currentTime;
    public TextMeshProUGUI timeText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets the base time to 0 and then turns on the stopwatch
        currentTime = 0;
        stopwatchActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the stopwatch is on, then starts timing
        if (stopwatchActive == true)
        {
            currentTime += Time.deltaTime;
        }        
        timeText.text = currentTime.ToString();
    }
}
