using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown myDropdown;

    void Start()
    {
        // listener
        myDropdown.onValueChanged.AddListener(SaveDropdownValue);
    }

    void SaveDropdownValue(int value)
    {
        // Store value in the GameManager
        GameManager.Instance.dropdownSelection = value;
        Debug.Log("Selected Dropdown Value: " + value);
    }
}
