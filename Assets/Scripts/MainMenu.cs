using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        // Load the maze scene
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        // Display a debug message in the console
        Debug.Log("Quit Game");

        // Quit the application (works in standalone builds)
        Application.Quit();
    }
}
