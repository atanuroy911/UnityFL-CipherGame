using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject gridObject;
    public string audioSourceObjectName;
    public AudioSource audioSource;
    private List<Transform> highlightedGrandchildren = new List<Transform>();

    void Start()
    {
        GameObject obj = GameObject.Find(audioSourceObjectName);

        if (gridObject != null)
        {
            // Get the number of children of the "grid" GameObject
            int rowCount = gridObject.transform.childCount;

            // Iterate through each row of the "grid" GameObject
            for (int row = 0; row < rowCount; row++)
            {
                Transform rowTransform = gridObject.transform.GetChild(row);

                // Attach click listeners to each grandchild in the row
                for (int col = 0; col < rowTransform.childCount; col++)
                {
                    Transform grandChild = rowTransform.GetChild(col);

                    // Add a click listener to each grandchild
                    AddClickListener(grandChild, row, col);
                }
            }
        }
        else
        {
            Debug.LogWarning("GameObject named 'grid' not found.");
        }
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

    void AddClickListener(Transform grandChild, int row, int col)
    {
        // Get the Image component of the grandchild
        Image image = grandChild.GetComponent<Image>();

        // Check if Image component exists
        if (image != null)
        {
            // Attach a click listener to the grandchild
            EventTrigger trigger = grandChild.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = grandChild.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((eventData) => { OnGrandchildClicked(row, col); });

            trigger.triggers.Add(entry);
            
        }
    }



    void OnGrandchildClicked(int row, int col)
    {
        // Deselect all previously highlighted grandchild elements
        PlayAudio();
        foreach (Transform highlightedGrandchild in highlightedGrandchildren)
        {
            Image highlightImage = highlightedGrandchild.GetComponent<Image>();
            if (highlightImage != null)
            {
                if (highlightedGrandchild.GetSiblingIndex() == 0 || highlightedGrandchild.parent.GetSiblingIndex() == 0)
                {
                    // Set the color of the first row and first grid to #828282
                    highlightImage.color = new Color(0.51f, 0.51f, 0.51f, 1f);
                }
                else
                {
                    // Restore original color
                    highlightImage.color = Color.white;
                }
            }
        }
        highlightedGrandchildren.Clear();

        // Highlight all grandchild elements in the same column
        HighlightColumn(col);

        // Highlight all grandchild elements in the same row
        HighlightRow(row);
    }

    void HighlightColumn(int col)
    {
        // Iterate through each row
        int rowCount = gridObject.transform.childCount;
        for (int row = 0; row < rowCount; row++)
        {
            Transform rowTransform = gridObject.transform.GetChild(row);
            Transform grandChild = rowTransform.GetChild(col);
            Image image = grandChild.GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.yellow;
                highlightedGrandchildren.Add(grandChild);
            }
        }
    }

    void HighlightRow(int row)
    {
        Transform rowTransform = gridObject.transform.GetChild(row);
        int colCount = rowTransform.childCount;
        for (int col = 0; col < colCount; col++)
        {
            Transform grandChild = rowTransform.GetChild(col);
            Image image = grandChild.GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.yellow;
                highlightedGrandchildren.Add(grandChild);
            }
        }
    }
}
