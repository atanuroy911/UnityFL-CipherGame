using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySFX : MonoBehaviour
{
    // Start is called before the first frame update
    private static DontDestroySFX instance;
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
