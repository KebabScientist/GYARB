using TMPro;  // Import the TextMesh Pro namespace
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
   
    public TMP_Dropdown[] myDropdowns;

    void Start()
    {
        // Ensure each dropdown is properly referenced
        if (myDropdowns.Length == 12)
        {
            // Add listeners to each dropdown
            for (int i = 0; i < myDropdowns.Length; i++)
            {
                if (myDropdowns[i] != null)
                {
                    int index = i; // Capture the index for each dropdown
                    myDropdowns[i].onValueChanged.AddListener((value) => SaveDropdownValue(index, value));
                    Debug.Log("Listener added to dropdown " + index);  // Log to check if listeners are added
                }
                else
                {
                    Debug.LogError("Dropdown at index " + i + " is not assigned!");
                }
            }
        }
        else
        {
            Debug.LogError("Invalid number of elements: " + myDropdowns.Length);
        }
    }


    // This method is called when the dropdown value changes
    void SaveDropdownValue(int index, int value)
    {
        // Store the value in the GameManager (Singleton pattern)
        GameManager.Instance.SetDropdownValue(index, value);
    }
}
