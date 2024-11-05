using UnityEngine;

public class PlaySpecialSound : MonoBehaviour
{
    public AudioClip specialAudioClip;  // Assign the special audio clip in the inspector

    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component to the GameObject
        audioSource = GetComponent<AudioSource>();

        // If there's no AudioSource, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Called when another collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has entered the trigger area.");  // Debug log message
        PlaySound();
    }

    void PlaySound()
    {
        // Play the special sound if the clip is assigned
        if (specialAudioClip != null)
        {
            audioSource.PlayOneShot(specialAudioClip);
        }
        else
        {
            Debug.LogError("Special AudioClip not assigned.");
        }
    }
}
