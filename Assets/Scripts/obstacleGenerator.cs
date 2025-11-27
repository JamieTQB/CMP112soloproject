using UnityEngine;
using UnityEngine.UIElements;

public class obstacleGenerator : MonoBehaviour
{
    float randomX;
    float randomZ;
    Vector3 maxCoords;
    public GameObject Ground;
    public GameObject Obstacle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxCoords = Ground.GetComponent<Transform>().position;
        /*for (int i = 0; i > 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(0f, maxCoords.x), 5f, Random.Range(0f, maxCoords.y));
            Instantiate(Obstacle, position, Quaternion.identity);
            Debug.Log("cube spawned");
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 position = new Vector3(Random.Range(0f, maxCoords.x), 5f, Random.Range(0f, maxCoords.z));
            Instantiate(Obstacle, position, Quaternion.identity);
            Debug.Log("cube spawned");
        }
    }

    void generateObstacles()
    {
        
        
    }

}
