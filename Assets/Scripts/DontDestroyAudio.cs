using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour

{
    private static DontDestroyAudio instance;

    void Awake()
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
}
