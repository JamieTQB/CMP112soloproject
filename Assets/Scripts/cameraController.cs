using UnityEngine;

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
        offset = transform.position - player.transform.position;
        boostCheck = player.GetComponent<playerController>();
    }

    // 
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
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
