using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//this script is what handles the random generation of the cubes used as obstacles
public class obstacleGenerator : MonoBehaviour
{
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
        //this line makes sure that the cubes are generated on the floor rather than floating above due to the transformations the 3d objects have
        obstacleHeight = Obstacle.transform.localScale.y / 2;
        //these lines grab the number from the component that has their scale/position to use as the maximum grid point for the random number, multiplied due to some strange behaviour between the number used and the actual point in space
        maxCoordX = Ground.transform.localScale.x * 4;
        maxCoordZ = Ground.transform.localPosition.z * 2;

        //this section is what makes a new grid point, then it spawns a cube, then grabs it's bounding box to later check against itself to avoid overlaping obstacles, which doesn't work but i'm afraid to change this at this point as it took way to long to get working in the first place
        Vector3 position = new Vector3(Random.Range(minCoords.x * 4, maxCoordX), obstacleHeight, Random.Range(minCoords.z, maxCoordZ));
        Instantiate(Obstacle, position, Quaternion.identity);
        obstBounding = Obstacle.GetComponent<Collider>();
        //spawns in more obstacles, up to the amount asked for, minus one to account for the first spawned obstacle
        for (int i = 0; i < obstacleAmount - 1; i++)
        {
            if (!obstBounding.bounds.Intersects(obstBounding.bounds))
            {
                Instantiate(Obstacle, position, Quaternion.identity);
            }
            else
            {
                //should be getting a new position if the last one caused the colliders to overlap, again, doesn't fully work but changing it causes problems
                Vector3 position2 = new Vector3(Random.Range(minCoords.x, maxCoordX), obstacleHeight, Random.Range(minCoords.z, maxCoordZ));
                Instantiate(Obstacle, position2, Quaternion.identity);
            }
           
        }

    }

}
