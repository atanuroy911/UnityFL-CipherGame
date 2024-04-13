using UnityEngine;
using UnityEngine.UI;

public class GlobalButtonHandler : MonoBehaviour
{
    // Singleton instance
    private static GlobalButtonHandler instance;

    // Sound effect audio clip
    public AudioClip buttonClickSound;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of GlobalButtonHandler exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Function to play sound effect
    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    // Function to handle button click event
    public void OnButtonClick()
    {
        PlayButtonClickSound();
        Debug.Log("Button Clicked!");
        // Add your button click logic here
    }
}
