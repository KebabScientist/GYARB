using UnityEngine;
using TMPro;  // Import the TextMesh Pro namespace

public class DropdownManager : MonoBehaviour
{
    public TMP_Dropdown myDropdown;  // Reference to the TMP_Dropdown component

    void Start()
    {
        // Ensure the dropdown is referenced
        if (myDropdown != null)
        {
            // Add listener for when the dropdown value changes
            myDropdown.onValueChanged.AddListener(SaveDropdownValue);
        }
        else
        {
            Debug.LogError("TMP_Dropdown is not assigned!");
        }
    }

    // This method is called when the dropdown value changes
    void SaveDropdownValue(int value)
    {
        // Log the value that was selected in the dropdown
        Debug.Log("Selected Dropdown Value: " + value);

        // Store the selected value in the GameManager (Singleton pattern)
        GameManager.Instance.dropdownSelection = value;
    }
}
