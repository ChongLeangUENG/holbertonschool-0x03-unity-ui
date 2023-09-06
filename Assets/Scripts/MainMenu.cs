using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            // Change the trap material color to orange
            trapMat.color = new Color32(255, 112, 0, 255);

            // Change the goal material color to blue
            goalMat.color = Color.blue;
        }
        else
        {
            // Reset trap and goal materials to their default colors
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
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
