using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//knapp för att gå tbx till menyn från spelet 

public class GoMenu : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No previous scene available.");
        }
    }

}
