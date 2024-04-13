using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    public TMP_InputField UserInput;
    public GameObject RetryMessage;
    public GameObject LevelComplete;
    public static bool MessageShowing = false;
    [SerializeField] private string Answer;

    public string audioSourceObjectName; // Name of the GameObject with the AudioSource component attached
    private AudioSource audioSource;

    public AudioClip successAudioClip;
    public AudioClip failedAudioClip;


    // Start is called before the first frame update
    void Start()
    {
        RetryMessage.SetActive(false);
        LevelComplete.SetActive(false);
        MessageShowing = false;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ClickEnter();
        }
    }

    //Button is clicked after player answer input
    public void ClickEnter()
    {
        if (UserInput.text.ToUpper() == Answer)
        {
            StarShower.Instance.StartShower();
            audioSource.PlayOneShot(successAudioClip);
            Debug.LogWarning("Level completed.");
            LevelComplete.SetActive(true);

        }
        else
        {
            audioSource.PlayOneShot(failedAudioClip);
            RetryMessage.SetActive(true);
            Time.timeScale = 0f;
            MessageShowing = true;
        }
    }

    //Resume current level
    public void ExitMsg()
    {
        RetryMessage.SetActive(false);
        Time.timeScale = 1f;
        MessageShowing = false;
    }
}
