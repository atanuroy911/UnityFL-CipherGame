using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    // public GameObject audioSourceObject; // Drag and drop the GameObject with the AudioSource component attached in the Unity Editor
    // public AudioClip audioClip; // Assign the audio clip you want to play in the Unity Editor

    private Button button;
    public string audioSourceObjectName; // Name of the GameObject with the AudioSource component attached

    private AudioSource audioSource;

    void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener for the button click event
        button.onClick.AddListener(PlayAudio);
        GameObject obj = GameObject.Find(audioSourceObjectName);
        if (obj != null)
        {
            // Get the AudioSource component from the found GameObject
            audioSource = obj.GetComponent<AudioSource>();
        }
        else
        {
            // Log an error if the AudioSource GameObject is not found
            Debug.LogError("AudioSource GameObject named " + audioSourceObjectName + " not found!");
        }

    }

    void PlayAudio()
    {
        // Check if audioSource and audioClip are assigned
        if (audioSource != null)
        {
            // Play the assigned audio clip
            audioSource.Play();
        }
        else
        {
            // Log a warning if AudioSource or AudioClip is not assigned
            Debug.LogWarning("AudioSource or AudioClip is not assigned!");
        }
    }

    // // Clean up the listener when this script is disabled or destroyed
    // void OnDisable()
    // {
    //     button.onClick.RemoveListener(PlayAudio);
    // }

    // void OnDestroy()
    // {
    //     button.onClick.RemoveListener(PlayAudio);
    // }
}
