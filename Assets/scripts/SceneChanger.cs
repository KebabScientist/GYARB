using UnityEngine;
using UnityEngine.SceneManagement;  // Required to load different scenes

public class SceneChanger : MonoBehaviour
{
    // Method to change the scene
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Attempting to load scene: " + sceneName); // Log the scene name you're trying to load

        // Load the scene
        SceneManager.LoadScene(sceneName);

        // You may never get here because the scene is changing immediately, 
        // but this line is helpful if the scene doesn't change as expected.
        Debug.Log("Scene loading triggered");
    }
}