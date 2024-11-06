using UnityEngine;
using UnityEngine.UI;

public class DigitalSpeedometer : MonoBehaviour
{
    public CarControlTest1 carController; // Reference to CarControlTest1 script
    public Text speedText;                // UI Text element for displaying speed

    void Update()
    {
        if (carController == null || speedText == null) return;

        // Update the UI text with the speed value
        float speedKmh = carController.speed;
        speedText.text = $"{speedKmh:0.0} km/h";
    }
}
