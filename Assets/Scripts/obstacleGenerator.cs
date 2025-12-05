using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class obstacleGenerator : MonoBehaviour
{
    float randomX;
    float randomZ;
    float maxCoordX;
    float maxCoordZ;
    float obstacleHeight;
    Collider obstBounding;

    public Vector3 minCoords;
    public GameObject Ground;
    public GameObject Obstacle;
    public float obstacleAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleHeight = Obstacle.transform.localScale.y / 2;
        maxCoordX = Ground.transform.localScale.x * 4;
        maxCoordZ = Ground.transform.localPosition.z * 2;   
        //minCoords = -Ground.transform.localScale;
        Vector3 position = new Vector3(Random.Range(minCoords.x * 4, maxCoordX), obstacleHeight, Random.Range(minCoords.z, maxCoordZ));
        obstBounding = Obstacle.GetComponent<Collider>();
        Instantiate(Obstacle, position, Quaternion.identity);
        for (int i = 0; i < obstacleAmount - 1; i++)
        {
            if (!obstBounding.bounds.Intersects(obstBounding.bounds))
            {
                Instantiate(Obstacle, position, Quaternion.identity);
            }
            else
            {
                Vector3 position2 = new Vector3(Random.Range(minCoords.x, maxCoordX), obstacleHeight, Random.Range(minCoords.z, maxCoordZ));
                Instantiate(Obstacle, position2, Quaternion.identity);
            }
           
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateObstacles()
    {
        
        
    }

}
