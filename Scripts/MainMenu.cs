using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    // This method is called when the "Play" and other buttons are clicked
    public void GoToScene(string SceneName)
    {
        // Load the game scene
        SceneManager.LoadScene(SceneName);
        Debug.Log("Button Clicked: ");
    }
    // This method is called when the "Quit" button is clicked
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        Debug.Log("Game has been quit.");

        // If running in the editor, stop playing the scene
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

