using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RotateObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public TextMeshProUGUI ShiftText;

    private int Shift;

    public string audioSourceObjectName; // Name of the GameObject with the AudioSource component attached

    private AudioSource audioSource;

    public AudioClip RotateAudioClip;

    private bool Rotating = false;
    private Vector3 StartMousePos;
    private Vector3 CurrentMousePos;
    private float Angle;

    void Start()
    {
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

    public void OnPointerDown(PointerEventData eventData)
    {
        Rotating = true;
        StartMousePos = eventData.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Rotating)
        {
            CurrentMousePos = eventData.position;
            Vector3 MouseMovement = CurrentMousePos - StartMousePos;

            Angle = Mathf.Atan2(MouseMovement.y, MouseMovement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Angle);

            int ShiftTemp = Mathf.RoundToInt(Angle / (360 / 26));
            Shift = Angle <= 0 ? -ShiftTemp : 26 - ShiftTemp;


            audioSource.PlayOneShot(RotateAudioClip);
            ShiftText.text = Shift.ToString();

            Debug.Log("Rotating by " + Angle + ", Shifting by " + Shift);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Rotating = false;
    }
}
