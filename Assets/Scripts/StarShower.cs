using UnityEngine;
using UnityEngine.UI;

public class StarShower : MonoBehaviour
{
    public static StarShower Instance;
    public Sprite starSprite; // Assign your star sprite in the inspector
    public RectTransform canvasRectTransform; // Reference to the canvas RectTransform
    private float spawnInterval = 0.1f; // Time between spawning stars
    private float duration = 4f; // Duration of the star shower
    private float fallSpeed = 400f; // Speed at which stars fall

    private float timer = 0f;
    private int numStarsToSpawn = 3;

    private float minDistanceBetweenStars = 100f;

    public bool isShowering = false;


    private void Start()
    {
        Instance = this; // Set the static instance reference

        // Get the canvas RectTransform
        Canvas canvas = GetComponent<Canvas>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();

        // // Set canvas size to match screen size
        // canvasRectTransform.sizeDelta = new Vector2(canvas.width, Screen.height);
    }

    private void Update()
    {
        if (!isShowering)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            isShowering = false;
            timer = 0f;
            return;
        }

        if (timer % spawnInterval < Time.deltaTime)
        {
            SpawnStar();
        }
    }

    private void SpawnStar()
    {
        for (int i = 0; i < numStarsToSpawn; i++)
        {
            try
            {
                bool isPositionValid = false;
                Vector2 spawnPosition = Vector2.zero;

                // Keep generating a random position until a valid one is found
                while (!isPositionValid)
                {
                    // Randomize spawn position outside canvas bounds
                    float canvasWidth = canvasRectTransform.rect.width;
                    float spawnX = Random.Range(-canvasWidth / 2f, canvasWidth / 2f);
                    float spawnY = canvasRectTransform.rect.height + 100f; // Offset to ensure stars are initially above canvas

                    spawnPosition = new Vector2(spawnX, spawnY);

                    // Check if this position is valid (not too close to any other star)
                    isPositionValid = IsPositionValid(spawnPosition, minDistanceBetweenStars);
                }

                // Create star UI Image dynamically
                GameObject starObject = new GameObject("Star");
                Image starImage = starObject.AddComponent<Image>();
                starImage.sprite = starSprite;

                // Set parent to canvas
                starObject.transform.SetParent(canvasRectTransform, false);

                // Set star size to be 100x100
                RectTransform starRectTransform = starObject.GetComponent<RectTransform>();
                starRectTransform.sizeDelta = new Vector2(100f, 100f);

                // Set star position
                starRectTransform.anchoredPosition = spawnPosition;

                // Make star fall
                Rigidbody2D rb = starObject.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0; // Disable default gravity
                rb.velocity = Vector2.down * fallSpeed;

                // Destroy the star after the duration
                Destroy(starObject, duration);
            }
            catch (System.Exception e)
            {
                Debug.LogError("An error occurred while spawning a star: " + e.Message);
            }
        }
    }


    private bool IsPositionValid(Vector2 position, float minDistance)
    {
        // Check distance from all existing stars
        foreach (Transform child in canvasRectTransform)
        {
            RectTransform starRectTransform = child.GetComponent<RectTransform>();
            if (starRectTransform != null)
            {
                float distance = Vector2.Distance(position, starRectTransform.anchoredPosition);
                if (distance < minDistance)
                {
                    return false; // Position is too close to another star
                }
            }
        }
        return true; // Position is valid
    }

    public void StartShower()
    {
        // Reset timer
        timer = 0f;
        isShowering = true;
    }
}
