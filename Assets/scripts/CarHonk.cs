using UnityEngine;

public class CarHonk : MonoBehaviour
{
    // Assign the honk sound clip in the inspector
    public AudioClip honkClip;

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the car
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            Honk();
        }
    }

    void Honk()
    {
        // Play the honk sound if it is assigned
        if (honkClip != null)
        {
            audioSource.PlayOneShot(honkClip);
        }
    }
}
