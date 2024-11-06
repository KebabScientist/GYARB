using UnityEngine;

public class scene2manager : MonoBehaviour
{
    void Start()
    {
        // Loop through the 6 dropdown values and print them
        for (int i = 0; i < 6; i++)
        {
            int savedDropdownValue = GameManager.Instance.GetDropdownValue(i);
            Debug.Log("Dropdown " + i + " value: " + savedDropdownValue);
        }
    }



}
