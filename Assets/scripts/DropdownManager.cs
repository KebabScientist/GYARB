using TMPro;  // Import the TextMesh Pro namespace
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    // Reference to the 6 dropdowns in the inspector
    public TMP_Dropdown[] myDropdowns;

    void Start()
    {
        // Ensure each dropdown is properly referenced
        if (myDropdowns.Length == 12)
        {
            // Add listeners to each dropdown
            for (int i = 0; i < myDropdowns.Length; i++)
            {
                int index = i; // Capture the index for each dropdown
                myDropdowns[i].onValueChanged.AddListener((value) => SaveDropdownValue(index, value));
            }
        }
        else
        {
            Debug.LogError("invalid nr of elements" + myDropdowns.Length);
        }
    }

    // This method is called when the dropdown value changes
    void SaveDropdownValue(int index, int value)
    {
        // Store the value in the GameManager (Singleton pattern)
        GameManager.Instance.SetDropdownValue(index, value);
    }
}
