using UnityEngine;

public class goalScript : MonoBehaviour
{
    public GameObject player;
    gameStateClass state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("finish!");
            
        }
    }
}
