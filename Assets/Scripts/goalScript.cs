using UnityEngine;
using UnityEngine.SceneManagement;

//this script is for what happens when the player reaches the goal
public class goalScript : MonoBehaviour
{
    public GameObject player;
    public Timer timerActive;
    public TimeSheet timesheet;
    gameStateClass state;
    //checks when the player collides with the yellow goal zone, and turns off the timer
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            SceneManager.LoadScene("Results");
            timerActive.stopwatchActive = false;
        }
    }
}
