using UnityEngine;

//this script is for the camera and any movement or changes
public class cameraController : MonoBehaviour
{
    public GameObject player;
    public float t = 0.2f;
    private playerController boostCheck;
    private Vector3 offset;
    float baseFOV = 60f;
    float boostFOV = 70f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //sets the offset of the camera to the player
        offset = transform.position - player.transform.position;
        //gets the boost bool from the player controller script
        boostCheck = player.GetComponent<playerController>();
    }

    // 
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //if the player is boosting, this changes the FOV slightly to help display the change of speed, and sets it back when the boost runs out
        if (boostCheck.boosting)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, boostFOV, t);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, baseFOV, t); 
        }
    }
}
