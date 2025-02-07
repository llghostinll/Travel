using UnityEngine;
using UnityEngine.SceneManagement; // Include this to manage scenes

public class EndScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that enters the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Load the next scene or end the game
            EndCurrentScene();
        }
    }

    private void EndCurrentScene()
    {
        // Optionally, you can load a specific scene by name or index
        // For example, to load a scene named "GameOver":
        SceneManager.LoadScene("GameOver"); // Change "GameOver" to your desired scene name

        // Alternatively, if you want to quit the application (for builds):
        // Application.Quit();
    }
}