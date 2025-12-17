using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

//this script is for taking the time from the game and displaying it to the player at the end
public class TimeSheet : MonoBehaviour
{
    public Timer attemptTime;
    public TextMeshProUGUI textDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayFinalTime();
    }
    public void displayFinalTime()
    {
        //shows the time taken, multiplied and divided as such to show 2 decimal points
        float timeTaken = (Mathf.Round(Timer.currentTime*100)) / 100.0f;
        textDisplay.text = "completed in " + timeTaken.ToString() + " seconds";
    }
}
