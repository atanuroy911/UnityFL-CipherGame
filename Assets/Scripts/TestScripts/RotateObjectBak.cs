using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class RotateObjectBak : MonoBehaviour
{
    public TextMeshProUGUI ShiftText;
    private int Shift;

    private bool Rotating = false;
    private Vector3 StartMousePos;
    private Vector3 CurrentMousePos;
    private float Angle;    


    // Update is called once per frame
    void Update()
    {
        //Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //TODO: Check out Camera.main.ScreenToRay
        if (Input.GetMouseButtonDown(0))
        {
            Rotating = true;
            StartMousePos = Input.mousePosition;

            /*Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                MeshRenderer hitObject = hitInfo.collider.GetComponent<MeshRenderer>();
                if (hitObject)
                {
                    Rotating = true;
                    StartMousePos = Input.mousePosition;
                }
            }*/

            /*
                        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
                        if (hitData)
                        {
                            Rotating = true;
                            StartMousePos = Input.mousePosition;
                        }*/

            /*Collider2D TargetObject = Physics2D.OverlapPoint(MousePos);
            if (TargetObject)
            {
                Rotating = true;
                StartMousePos = Input.mousePosition;
            }*/
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Rotating = false;
        }

        if (Rotating)
        {
            CurrentMousePos = Input.mousePosition;
            Vector3 MouseMovement = CurrentMousePos - StartMousePos;

            Angle = Mathf.Atan2(MouseMovement.y, MouseMovement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Angle);

            int ShiftTemp = (int)System.Math.Round(Angle / (360 / 26));
            if (Angle <= 0)
            {
                Shift = -ShiftTemp;
            }
            else
            {
                Shift = 26 - ShiftTemp;
            }

            ShiftText.text = Shift.ToString();

            Debug.Log("Rotating by " + Angle + ", Shifting by " + Shift);
        }
    }
}