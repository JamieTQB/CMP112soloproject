using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStateClass : MonoBehaviour
{

    public enum gameState
    {
        Menu,
        Active,
        Pause,
        GameOver,
        Results
    }
    public gameState gameplayState;
    public bool canMove;

    // Update is called once per frame
    void Update()
    {
        switch (gameplayState)
        {
            case gameState.Menu:
                SceneManager.LoadScene("Menu");
                canMove = false;
                break;
            case gameState.Active:
                canMove = true;
                break;
            case gameState.Pause:
                canMove = false;
                break;
            case gameState.GameOver:
                canMove = false;
                break;
            case gameState.Results:
                canMove = false;
                break;          
        }
    }
}
