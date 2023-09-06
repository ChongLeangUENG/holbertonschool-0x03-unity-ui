using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        // Load the maze scene
        SceneManager.LoadScene("maze");
    }
}
