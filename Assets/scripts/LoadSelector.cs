using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelector : MonoBehaviour
{
    public void LoadVehicleSelector()
    {
        SceneManager.LoadScene("VSelect"); // Loads the vehicle selector scene
    }
}
