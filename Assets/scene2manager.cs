using UnityEngine;

public class scene2manager : MonoBehaviour
{
    void Start()
    {
        // Access the dropdown value from GameManager in Scene 2
        int savedDropdownValue = GameManager.Instance.GetDropdownValue();

        // Log the value to verify it's being accessed correctly
        Debug.Log("Dropdown value from Scene 1: " + savedDropdownValue);

        // Use the value for your game logic (e.g., apply it to some game mechanic)
    }
}
