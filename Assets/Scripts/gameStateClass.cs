using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//this script is mainly for checking and changing the gamestate, based off player input or events within the game
public class gameStateClass : MonoBehaviour
{
    public gameState gameplayState;
    Scene CurrentScene;
    private void Start()
    {
        //checks current scene and sets gamestate accordingly
        CurrentScene = SceneManager.GetActiveScene();
        switch (CurrentScene.name)
        {
            case "Menu":
                gameplayState = gameState.Menu;
                break;
            case "GameScene":
                gameplayState = gameState.Active;
                break;
            case "Results":
                gameplayState = gameState.Results;
                break;
        }        
    }
    public enum gameState
    {
        Menu,
        Active,
        Results
    }
    void OnPause()
    {
        //this checks what the gamestate is when you hit escape and does a specific thing accordingly
        switch (gameplayState)
        {
            case gameState.Menu:
                EditorApplication.isPlaying = false;
                Application.Quit();
                break;
            case gameState.Active:
                break;
            case gameState.Results:
                EditorApplication.isPlaying = false;
                Application.Quit();
                break;
        }
    }
    void OnStart()
    {
        //checks the gamestate when you hit enter and does something accordingly
        switch (gameplayState)
        {
            case gameState.Menu:
                gameplayState = gameState.Active;
                changeScene();
                break;
            case gameState.Active:
                break;
            case gameState.Results:
                gameplayState = gameState.Active;
                changeScene();
                break;

                
        }
    }
    void changeScene()
    {
        //mainly here as a failsafe to make sure when the gamestate is changed, the scene is set to the corresponding scene
        switch (gameplayState)
        {
            case gameState.Menu:
                SceneManager.LoadSceneAsync("Menu");
                break;
            case gameState.Active:
                SceneManager.LoadSceneAsync("GameScene");
                break;
            case gameState.Results:
                SceneManager.LoadSceneAsync("Results");
                break;
        }
    }

}
